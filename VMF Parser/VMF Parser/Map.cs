using System.IO;
using System.Text.RegularExpressions;

namespace VMFParser
{
    public sealed class Map
    {
        public VersionInfo VersionInfo { get; private set; }

        public static Map Parse(string path)
        {
            byte[] data = File.ReadAllBytes(path);
            Parser parser = new Parser(new Map(), data);
            return parser.Parse();
        }
    }
}