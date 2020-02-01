using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
namespace UnbreakablePasswordGenerator
{
    public sealed partial class MainPage : Page
    {
        private readonly int[] IntList; // Data source for UI Combobox PasswordLengthSelect
        public MainPage()
        {
            this.InitializeComponent();
            IntList = Enumerable.Range(UPGConstants.MinPasswordLength, 5000).ToArray();

            // Ensure it is impossible to select a null value by providing a default
            PasswordLengthSelect.SelectedIndex = UPGConstants.MinPasswordLength; 
        }

        private int GetPasswordLengthAsInt()
        {
            string selectedLength = PasswordLengthSelect.Text;
            return Convert.ToInt32(PasswordLengthSelect.SelectedItem.ToString());

        }

        private void ToggleSwitched(object sender, RoutedEventArgs e)
        {
            // Read Toggsles and build Charset based on selections
            CharacterSet charSet = new CharacterSet
            {
                ContainsLowercase = LowerCaseSwitch.IsOn,
                ContainsUppercase = UpperCaseSwitch.IsOn,
                ContainsNumerals = NumeralSwitch.IsOn,
                ContainsSymbols = SymbolSwitch.IsOn
            };

            CharacterSetVisualiser characterSetVisualiser = new CharacterSetVisualiser(charSet);
            CharacterSetVisualiserTXTBox.Text = characterSetVisualiser.GenerateCharSetString();
            
            int passwordLength = this.GetPasswordLengthAsInt();
            
            // Generate Charset and init password generator
            List<String> characterSet = charSet.GenerateCharSet();
            GeneratedPassword generatedPassword = new GeneratedPassword(characterSet, passwordLength);

            // Set output text as the value of the Generated password
            PasswordOutputTxtBox.Text = generatedPassword.Password;
        }

    }


}
