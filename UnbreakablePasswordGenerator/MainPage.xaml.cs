using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Linq;
using Windows.UI.Popups;
namespace UnbreakablePasswordGenerator
{
    public sealed partial class MainPage : Page
    {
        int[] IntList; // Data source for UI Combobox PasswordLengthSelect
        public MainPage()
        {
            this.InitializeComponent();
            IntList = Enumerable.Range(1, 200).ToArray();

            // Ensure it is impossible to select a null value by providing a default
            PasswordLengthSelect.SelectedIndex = UPGConstants.MinPasswordLength; 
            
            
        }

        private int GetPasswordLengthAsInt()
        {
            string selectedLength = PasswordLengthSelect.Text;
            //ComboBoxItem selectedLengthItem = PasswordLengthSelect.SelectedItem as ComboBoxItem;
            //string selectedPasswordLengthString = selectedLength.Content.ToString();
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
            
            int passwordLength = this.GetPasswordLengthAsInt();
            // TODO save value to class. Check if the value changed. If not, use condition to skip lines 
            // Read the desired length
            
            // Generate Charset and init password generator
            List<String> characterSet = charSet.GenerateCharSet();
            GeneratedPassword generatedPassword = new GeneratedPassword(characterSet, passwordLength);

            // Set output text as the value of the Generated password
            PasswordOutputTxtBox.Text = generatedPassword.Password;
        }

    }


}
