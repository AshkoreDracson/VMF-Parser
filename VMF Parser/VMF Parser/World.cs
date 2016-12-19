namespace VMFParser
{
    public class World : MapClass
    {
        public int? ID
        {
            get
            {
                return _properties["id"].Integer;
            }
        }
        public int? MapVersion
        {
            get
            {
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
    }
}