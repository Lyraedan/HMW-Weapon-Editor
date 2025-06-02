using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using FastFiles;
using Utils;

namespace FastFiles.Parsers
{
    public class H1FastFileParser : IFastFileParser
    {
        private byte[] decompressedData;

        private List<FastFileAsset> textures = new();
        private List<FastFileAsset> materials = new();
        private List<FastFileAsset> weapons = new();
        private List<FastFileAsset> models = new();
        private List<FastFileAsset> techsets = new();
        private List<FastFileAsset> rawfiles = new();
        private List<FastFileAsset> stringtables = new();

        public string EngineVersion => "H1";

        public void Parse(string filePath, IProgress<(int, string)> progress = null)
        {
            progress?.Report((10, "Reading FastFile from disk..."));
            byte[] data = File.ReadAllBytes(filePath);

            progress?.Report((20, "Locating compressed zlib blocks..."));
            try
            {
                decompressedData = CompressionUtils.DecompressMultipleZlibBlocks(data);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Failed to decompress FastFile data. It may be corrupted or use unsupported compression.", ex);
            }

            progress?.Report((60, "Scanning all assets..."));
            var grouped = FastFile.ScanAllAssets(decompressedData);

            textures = grouped["Texture"];
            materials = grouped["Material"];
            weapons = grouped["Weapon"];
            models = grouped["Model"];
            techsets = grouped["Techset"];
            rawfiles = grouped["RawFile"];
            stringtables = grouped["StringTable"];
            progress?.Report((100, "Finished parsing FastFile."));
        }

        public List<FastFileAsset> GetTextures() => textures;
        public List<FastFileAsset> GetMaterials() => materials;
        public List<FastFileAsset> GetWeapons() => weapons;
        public List<FastFileAsset> GetModels() => models;
        public List<FastFileAsset> GetTechsets() => techsets;
        public List<FastFileAsset> GetRawFiles() => rawfiles;
        public List<FastFileAsset> GetStringTables() => stringtables;
    }
}