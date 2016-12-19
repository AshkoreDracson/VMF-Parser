using System;

namespace VMFParser
{
    public class MapProperty
    {
        /// <summary>
        /// Returns the computed boolean of this property.
        /// </summary>
        public bool Boolean
        {
            get
            {
                return String == "1";
            }
        }
        /// <summary>
        /// Returns the computed decimal (double) of this property.
        /// </summary>
        public double? Decimal
        {
            get
            {
                try
                {
                    return double.Parse(String);
                }
                catch { return null; }
            }
        }
        /// <summary>
        /// Returns the computed integer of this property.
        /// </summary>
        public int? Integer
        {
            get
            {
                try
                {
                    return int.Parse(String);
                }
                catch { return null; }
            }
        }
        /// <summary>
        /// Returns the string value of this property.
        /// </summary>
        public string String { get; set; }
        /// <summary>
        /// Predicts what type of value it is based on the string, incompatible with booleans.
        /// Dynamic type so use with caution.
        /// </summary>
        public dynamic PredictedValue
        {
            get
            {
                int? i = Integer;
                if (i != null) return i;

                double? d = Decimal;
                if (d != null) return d;

                return String;
            }
        }

        public MapProperty(string s)
        {
            String = s;
        }

        public static implicit operator MapProperty(int i)
        {
            return new MapProperty(i.ToString());
        }
        public static implicit operator MapProperty(double d)
        {
            return new MapProperty(d.ToString());
        }
        public static implicit operator MapProperty(bool b)
        {
            return new MapProperty(b ? "1" : "0");
        }
        public static implicit operator MapProperty(string s)
        {
            return new MapProperty(s);
        }
    }
}