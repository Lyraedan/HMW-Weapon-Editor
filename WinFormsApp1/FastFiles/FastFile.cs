using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Forms;
using FastFiles.Parsers;

namespace FastFiles
{
    public class FastFile
    {
        public string FilePath { get; private set; }
        public List<FastFileAsset> Textures { get; private set; } = new();
        public List<FastFileAsset> Materials { get; private set; } = new();
        public List<FastFileAsset> Weapons { get; private set; } = new();
        public List<FastFileAsset> Models { get; private set; } = new();
        public List<FastFileAsset> Techsets { get; private set; } = new();
        public List<FastFileAsset> RawFiles { get; private set; } = new();
        public List<FastFileAsset> StringTables { get; private set; } = new();

        private static readonly Dictionary<string, string> ExtensionToType = new()
        {
            { "iwi", "Texture" },
            { "material", "Material" },
            { "weapon", "Weapon" },
            { "xmodel", "Model" },
            { "techset", "Techset" },
            { "rawfile", "RawFile" },
            { "stringtable", "StringTable" }
        };

        private FastFile() { }

        public static async Task<FastFile> LoadAsync(string path, string engine = "H1", IProgress<(int, string)> progress = null)
        {
            return await Task.Run(() =>
            {
                progress?.Report((0, "Initializing FastFile loader..."));

                var ff = new FastFile();
                ff.FilePath = path;

                progress?.Report((5, $"Preparing parser for engine: {engine}"));

                IFastFileParser parser = engine switch
                {
                    "H1" => new H1FastFileParser(),
                    _ => throw new NotSupportedException($"Engine {engine} not supported")
                };

                progress?.Report((10, "Parsing FastFile..."));

                parser.Parse(path, progress); // This now takes progress and reports stages

                ff.Textures = parser.GetTextures();
                ff.Materials = parser.GetMaterials();

                if (parser is H1FastFileParser h1)
                {
                    ff.Weapons = h1.GetWeapons();
                    ff.Models = h1.GetModels();
                    ff.Techsets = h1.GetTechsets();
                    ff.RawFiles = h1.GetRawFiles();
                    ff.StringTables = h1.GetStringTables();
                }

                progress?.Report((100, "Parsing complete."));
                return ff;
            });
        }


        public static List<FastFileAsset> FindAssets(byte[] decompressedData, string extension, string displayName)
        {
            List<FastFileAsset> results = new();
            string blob = Encoding.ASCII.GetString(decompressedData);

            var matches = Regex.Matches(blob, $@"([a-zA-Z0-9_/\\.\-]+)\.{extension}");
            foreach (Match match in matches)
            {
                string fullMatch = match.Value;
                string assetName = match.Groups[1].Value;
                byte[] assetBytes = Encoding.ASCII.GetBytes(fullMatch);

                int offset = SearchBytes(decompressedData, assetBytes);
                int size = 0;

                if (offset != -1 && extension == "iwi")
                {
                    // Find the actual IWI header nearby
                    int headerOffset = FindIwiHeader(decompressedData, offset);
                    if (headerOffset != -1 && headerOffset + 12 < decompressedData.Length)
                    {
                        size = BitConverter.ToInt32(decompressedData, headerOffset + 8); // Read file size from header
                    }
                }

                results.Add(new FastFileAsset
                {
                    Name = assetName,
                    Type = displayName,
                    Offset = offset,
                    Size = size
                });
            }

            return results;
        }

        public static Dictionary<string, List<FastFileAsset>> ScanAllAssets(byte[] decompressedData)
        {
            Dictionary<string, List<FastFileAsset>> result = new();
            foreach (var type in ExtensionToType.Values)
                result[type] = new();

            string blob = Encoding.ASCII.GetString(decompressedData);
            var pattern = @"([a-zA-Z0-9_/\\.\-]+)\.(iwi|material|weapon|xmodel|techset|rawfile|stringtable)";
            var matches = Regex.Matches(blob, pattern);

            foreach (Match match in matches)
            {
                string name = match.Groups[1].Value;
                string extension = match.Groups[2].Value;
                string type = ExtensionToType[extension];
                string fullMatch = match.Value;
                byte[] assetBytes = Encoding.ASCII.GetBytes(fullMatch);

                int offset = SearchBytes(decompressedData, assetBytes);
                int size = 0;

                if (extension == "iwi" && offset != -1)
                {
                    int headerOffset = FindIwiHeader(decompressedData, offset);
                    if (headerOffset != -1 && headerOffset + 12 < decompressedData.Length)
                        size = BitConverter.ToInt32(decompressedData, headerOffset + 8);
                }

                result[type].Add(new FastFileAsset
                {
                    Name = name,
                    Type = type,
                    Offset = offset,
                    Size = size
                });
            }

            return result;
        }


        private static int SearchBytes(byte[] haystack, byte[] needle)
        {
            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                bool found = true;
                for (int j = 0; j < needle.Length; j++)
                {
                    if (haystack[i + j] != needle[j])
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                    return i;
            }

            return -1;
        }

        private static int FindIwiHeader(byte[] data, int approxOffset)
        {
            // Search back up to 512 bytes from asset name for "IWi\0"
            int start = Math.Max(approxOffset - 512, 0);
            for (int i = start; i < approxOffset + 32 && i + 4 < data.Length; i++)
            {
                if (data[i] == 'I' && data[i + 1] == 'W' && data[i + 2] == 'i' && data[i + 3] == 0)
                    return i;
            }

            return -1;
        }


    }
}
