using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UnbreakablePasswordGenerator
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ToggleSwitched(object sender, RoutedEventArgs e)
        {
            // Read Toggles and build Charset based on selections
            CharacterSet charSet = new CharacterSet();
            charSet.ContainsLowercase = LowerCaseSwitch.IsOn;
            charSet.ContainsUppercase = UpperCaseSwitch.IsOn;
            charSet.ContainsNumerals = NumeralSwitch.IsOn;
            charSet.ContainsSymbols = SymbolSwitch.IsOn;

            // TODO save value to class. Check if the value changed. If not, use condition to skip lines 
            // Read the desired length

            //var passwordLengthSelectValue = PasswordLengthSelect.SelectedValue;
            //int passwordLength = Convert.ToInt32(passwordLengthSelectValue);
            
            // Generate Charset and init password generator
            List<String> characterSet = charSet.GenerateCharSet();
            GeneratedPassword generatedPassword = new GeneratedPassword(characterSet, characterSet.Count);

            // Set output text as the value of the Generated password
            PasswordOutputTxtBox.Text = generatedPassword.Password;
        }

    }
}
