using System.IO;
using System.Text.RegularExpressions;

namespace VMFParser
{
    public sealed class Map
    {
        public VersionInfo VersionInfo { get; private set; }

        public Map()
        {
            VersionInfo = new VersionInfo();
        }

        public static Map Parse(string path)
        {
            byte[] data = File.ReadAllBytes(path);
            Parser parser = new Parser(new Map(), data);
            return parser.Parse();
        }
    }
}