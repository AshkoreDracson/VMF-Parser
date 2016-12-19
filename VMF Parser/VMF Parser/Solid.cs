namespace VMFParser
{
    public class Solid : MapClass
    {
        public int? ID
        {
            get
            {
                if (!_properties.ContainsKey("id")) return null;

                return _properties["id"].Integer;
            }
        }
    }
}
