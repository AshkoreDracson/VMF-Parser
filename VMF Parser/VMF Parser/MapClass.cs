using System.Collections.Generic;
namespace VMFParser
{
    public abstract class MapClass
    {
        protected Dictionary<string, MapProperty> _properties { get; set; }

        public MapClass()
        {
            _properties = new Dictionary<string, MapProperty>();
        }

        public MapProperty GetProperty(string key)
        {
            return _properties[key];
        }
        public void SetProperty(string key, MapProperty value)
        {
            _properties[key] = value;
        }
    }
}