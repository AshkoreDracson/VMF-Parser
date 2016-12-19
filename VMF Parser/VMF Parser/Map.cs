using System.IO;
using System.Text.RegularExpressions;

namespace VMFParser
{
    public sealed class Map
    {
        public string Name { get; set; }
        public VersionInfo VersionInfo { get; private set; }
        public World World { get; private set; }

        public Map()
        {
            Name = "unnamed";
            VersionInfo = new VersionInfo();
            World = new World();
        }

        public static Map Parse(string path)
        {
            byte[] data = File.ReadAllBytes(path);
            Parser parser = new Parser(data);
            Map m = parser.Parse();
            m.Name = Path.GetFileNameWithoutExtension(path);
            return m;
        }
    }
}