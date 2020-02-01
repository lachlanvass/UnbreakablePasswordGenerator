using System;
using System.Text;

namespace UnbreakablePasswordGenerator
{
    class CharacterSetVisualiser
    {
        CharSetOps CharSetOps { get; set; }
        CharacterSet CharSet { get; set; }

        public CharacterSetVisualiser(CharacterSet charSet)
        {
            this.CharSet = charSet;
            this.CharSetOps = new CharSetOps
            {
                ContainsLowerCase = charSet.ContainsLowercase,
                ContainsUpperCase = charSet.ContainsUppercase,
                ContainsNumerals = charSet.ContainsNumerals,
                ContainsSymbols = charSet.ContainsSymbols
            };
        }

        public String GenerateCharSetString()
        {
            StringBuilder CharSetStringBuilder = new StringBuilder();

            if (this.CharSetOps.ContainsLowerCase)
                CharSetStringBuilder.Append(String.Join(",", this.CharSet.LowercaseChars));
            if (this.CharSetOps.ContainsUpperCase)
                CharSetStringBuilder.Append(String.Join(",", this.CharSet.UppercaseChars));
            if (this.CharSetOps.ContainsNumerals)
                CharSetStringBuilder.Append(String.Join(",", this.CharSet.Numerals));
            if (this.CharSetOps.ContainsSymbols)
                CharSetStringBuilder.Append(String.Join(",", this.CharSet.Symbols));

            return CharSetStringBuilder.ToString();
        }
    }

    public struct CharSetOps
    {      
        public bool ContainsLowerCase { get; internal set; }
        public bool ContainsUpperCase { get; internal set; }
        public bool ContainsNumerals { get; internal set; }
        public bool ContainsSymbols { get; internal set; }
    }
}
