namespace VMFParser
{
    public class VersionInfo : MapClass
    {
        public int? EditorVersion
        {
            get
            {
                if (!_properties.ContainsKey("editorversion")) return null;

                return _properties["editorversion"].Integer;
            }
        }
        public int? EditorBuild
        {
            get
            {
                if (!_properties.ContainsKey("editorbuild")) return null;

                return _properties["editorbuild"].Integer;
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
        public int? FormatVersion
        {
            get
            {
                if (!_properties.ContainsKey("formatversion")) return null;

                return _properties["formatversion"].Integer;
            }
        }
        public bool Prefab
        {
            get
            {
                if (!_properties.ContainsKey("prefab")) return false;

                return _properties["prefab"].Boolean;
            }
        }
    }
}
