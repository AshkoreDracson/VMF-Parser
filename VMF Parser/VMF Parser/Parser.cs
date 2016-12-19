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
        Map map;

        public Parser(Map map, byte[] data)
        {
            this.data = Encoding.UTF8.GetString(data).Replace("\r", "").Split('\n');
        }

        public Map Parse()
        {
            Map map = new Map();
            Node current = null;

            for (int i = 0; i < data.Length; i++)
            {
                string line = data[i];
                if (IsEmpty(line)) continue;

                Match propertyMatch = propertyRegex.Match(line);
                if (propertyMatch != null)
                {
                    
                }
            }

            return map;
        }


        string DismissComment(string s)
        {
            return s.Remove(commentRegex.Match(s).Index);
        }
        bool IsEmpty(string s)
        {
            return DismissComment(s).Trim().Length <= 0;
        }
    }
}