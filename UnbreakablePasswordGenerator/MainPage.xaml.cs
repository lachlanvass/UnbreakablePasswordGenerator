using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
namespace UnbreakablePasswordGenerator
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private int GetPasswordLengthAsInt()
        {
            ComboBoxItem selectedLengthItem = PasswordLengthSelect.SelectedItem as ComboBoxItem;
            string selectedPasswordLengthString = selectedLengthItem.Content.ToString();
            return Convert.ToInt32(selectedPasswordLengthString);

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

            int passwordLength = this.GetPasswordLengthAsInt();
            // TODO save value to class. Check if the value changed. If not, use condition to skip lines 
            // Read the desired length
            
            // Generate Charset and init password generator
            List<String> characterSet = charSet.GenerateCharSet();
            GeneratedPassword generatedPassword = new GeneratedPassword(characterSet, characterSet.Count);

            // Set output text as the value of the Generated password
            PasswordOutputTxtBox.Text = generatedPassword.Password;
        }

    }
}
