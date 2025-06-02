using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFiles
{
    public class FastFileAsset
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public long Offset { get; set; }
        public int Size { get; set; }
    }
}
