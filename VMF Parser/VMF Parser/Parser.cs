using System.Text;
using System.Text.RegularExpressions;
namespace VMFParser
{
    class Parser
    {
        // Regex
        Regex commentRegex = new Regex(@"\/\/(.+)");

        int cur = 0;
        string[] data;
        Map map;

        public Parser(Map map, byte[] data)
        {
            this.data = Encoding.UTF8.GetString(data).Replace("\r", "").Split('\n');
        }

        public Map Parse()
        {
            Map map = new Map();
            cur = 0;
            ParseStep();
            return map;
        }

        void ParseStep(Node node = null)
        {
            if (cur >= data.Length - 1) return;

            string s = data[cur];
            s = DismissComment(s).Trim().Replace("\t", ""); // Clean string of comments, extra spaces & tabs

            cur++;
            ParseStep(node);
        }


        string DismissComment(string s)
        {
            return s.Remove(commentRegex.Match(s).Index);
        }
    }
}