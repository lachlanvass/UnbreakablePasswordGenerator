using System;
using System.Collections.Generic;
using System.Text;

namespace UnbreakablePasswordGenerator
{
    public class GeneratedPassword
    {
        public String Password { get; set; }
        private List<String> CharSet { get; set; }
        public int SelectedPasswordLength { get; set; }
        public GeneratedPassword(List<String> charSet, int length)
        {
            this.CharSet = charSet;
            SelectedPasswordLength = length;

            if (CharSet.Count > UPGConstants.MinPasswordLength)
            {
                this.Password = this.GenerateRandomPasswordOfLength(SelectedPasswordLength);
            }
            else
            {
                this.Password = UPGConstants.PasswordPrompt;
            }
        }
        public GeneratedPassword()
        {
            
            
        }

        private String GenerateRandomPasswordOfLength(int length)
        {
            StringBuilder sb = new StringBuilder();
            Random randomCharGenerator = new Random();
            
            for (byte i = 0; i <= length; i++)
            {
                int newRandomInt = randomCharGenerator.Next(0, length - 1);

                // Get random char from CharSet using newRandomInt

                String randomChar = this.CharSet[newRandomInt];
                sb.Append(randomChar);
            }

            return sb.ToString();
        }

        public override string ToString()
        {

            return this.Password;
        }
    }
}
