using System;
using System.Collections.Generic;

namespace UnbreakablePasswordGenerator
{
    public class CharacterSet
    {
        public Boolean ContainsLowercase { get; set; }
        public Boolean ContainsUppercase { get; set; }
        public Boolean ContainsNumerals { get; set; }
        public Boolean ContainsSymbols { get; set; }
        public List<String> CharSet { get; set; } // remember to init before use

        public string[] LowercaseChars = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                            "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
        public string[] UppercaseChars = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
                                            "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        public string[] Numerals = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        
        public string[] Symbols = { "!", "@", "#", "$", "%", "^", "&", "(", ")", "-", "_", "+", "=", 
                                      "{", "[", "}", "]", "|", "*", "~", "`", ":", ";"};
        public CharacterSet()
        {
            // Set all booleans to false by default
            ContainsLowercase = false;
            ContainsUppercase = false;
            ContainsNumerals = false;
            ContainsSymbols = false;
        }

        public List<String> GenerateCharSet()
        {
            List<String> OutputList = new List<string>();
            if (ContainsLowercase)
            {
                OutputList.AddRange(LowercaseChars);
            }

            if (ContainsUppercase)
            {
                OutputList.AddRange(UppercaseChars);
            }

            if (ContainsNumerals)
            {
                OutputList.AddRange(Numerals);
            }

            if (ContainsSymbols)
            {
                OutputList.AddRange(Symbols);
            }

            return OutputList;
        }
    }
}
