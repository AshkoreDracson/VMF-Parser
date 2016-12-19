namespace VMFParser
{
    class ParseException : System.Exception
    {
        public ParseException() : base() { }
        public ParseException(string message) : base(message) { }
    }
}