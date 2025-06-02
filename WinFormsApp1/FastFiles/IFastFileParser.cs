using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFiles.Parsers
{
    public interface IFastFileParser
    {
        string EngineVersion { get; }
        void Parse(string filePath, IProgress<(int, string)> progress = null);
        List<FastFileAsset> GetTextures();
        List<FastFileAsset> GetMaterials();
    }

}
