using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
