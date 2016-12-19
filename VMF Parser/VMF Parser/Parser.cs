using System.Text;
using System.Text.RegularExpressions;
namespace VMFParser
{
    class Parser
    {
        // Regex
        Regex commentRegex = new Regex(@"\/\/(.*)");
        Regex propertyRegex = new Regex("\"(.*)\".+\"(.*)\"");

        string[] data;

        public Parser(Map map, byte[] data)
        {
            this.data = Encoding.UTF8.GetString(data).Replace("\r", "").Replace("\t", "").Split('\n');
        }

        public Map Parse()
        {
            Map map = new Map();
            Node curNode = null;
            string potentialClassName = string.Empty;

            for (int i = 0; i < data.Length; i++)
            {
                string line = Clean(data[i]);
                if (IsEmpty(line)) continue;

                Match propertyMatch = propertyRegex.Match(line);
                if (propertyMatch != null && propertyMatch.Success)
                {
                    string key = propertyMatch.Groups[1].Value;
                    string value = propertyMatch.Groups[2].Value;

                    ParseProperty(map, curNode, key, value);
                }
                else // Anything that isn't a property, class names, brackets, etc...
                {
                    switch (line)
                    {
                        case "{":
                            Node newNode = new Node(potentialClassName, curNode);
                            curNode = newNode;
                            break;
                        case "}":
                            curNode = curNode.Parent;
                            break;
                        default:
                            potentialClassName = line;
                            break;
                    }
                }
            }

            return map;
        }

        void ParseProperty(Map map, Node node, string key, string value)
        {
            if (node == null)
                throw new ParseException("Property out of a scope");

            if (node.Name == "versioninfo") // Version info
            {
                switch (key)
                {
                    case "editorversion":
                        map.VersionInfo.EditorVersion = int.Parse(value);
                        break;
                    case "editorbuild":
                        map.VersionInfo.EditorBuild = int.Parse(value);
                        break;
                    case "mapversion":
                        map.VersionInfo.MapVersion = int.Parse(value);
                        break;
                    case "formatversion":
                        map.VersionInfo.FormatVersion = int.Parse(value);
                        break;
                    case "prefab":
                        map.VersionInfo.Prefab = int.Parse(value) == 1;
                        break;
                    default:
                        break;
                }
            }
        }

        string Clean(string s)
        {
            if (s.Length <= 0) return s;
            Match m = commentRegex.Match(s);
            if (m == null || !m.Success) return s;
            string dismissed = s.Remove(m.Index).Trim();
            return dismissed;
        }
        bool IsEmpty(string s)
        {
            return s.Trim().Length <= 0;
        }
    }
}