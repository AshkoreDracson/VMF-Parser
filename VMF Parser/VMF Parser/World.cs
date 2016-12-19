using System.Collections.Generic;

namespace VMFParser
{
    public class World : MapClass
    {
        public int? ID
        {
            get
            {
                if (!_properties.ContainsKey("id")) return null;

                return _properties["id"].Integer;
            }
        }
        public int? MapVersion
        {
            get
            {
                if (!_properties.ContainsKey("mapversion")) return null;

                return _properties["mapversion"].Integer;
            }
        }
        public string ClassName
        {
            get
            {
                return _properties["classname"].String;
            }
        }
        public string SkyName
        {
            get
            {
                return _properties["skyname"].String;
            }
        }

        public Dictionary<int, Solid> Solids { get; private set; }

        public World()
        {
            Solids = new Dictionary<int, Solid>();
        }
    }
}