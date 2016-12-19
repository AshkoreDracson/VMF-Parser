namespace VMFParser
{
    public class VersionInfo : MapClass
    {
        public int? EditorVersion
        {
            get
            {
                return _properties["editorversion"].Integer;
            }
        }
        public int? EditorBuild
        {
            get
            {
                return _properties["editorbuild"].Integer;
            }
        }
        public int? MapVersion
        {
            get
            {
                return _properties["mapversion"].Integer;
            }
        }
        public int? FormatVersion
        {
            get
            {
                return _properties["formatversion"].Integer;
            }
        }
        public bool Prefab
        {
            get
            {
                return _properties["prefab"].Boolean;
            }
        }
    }
}
