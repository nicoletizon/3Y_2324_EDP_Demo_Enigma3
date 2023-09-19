using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3Y_2324_EDP_Demo_Enigma3
{

    public partial class MainWindow : Window
    {
        bool initialState = true;
        string defaultMessage = "Just type whatever...";

        public MainWindow()
        {
            InitializeComponent();

            if (initialState)
                lblInput.Content = defaultMessage;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (initialState)
            {
                initialState = false;
                lblInput.Content = KeyManager(e.Key);
            }
            else
            {
                string result = KeyManager(e.Key);
                if (e.Key == Key.Back)
                    lblInput.Content = lblInput.Content.ToString().Substring(0, Math.Max(0, lblInput.Content.ToString().Length - 1));
                else
                    lblInput.Content += result;
            }
        }

        private string KeyManager(Key input)
        {
            if (input == Key.Space)
                return " ";
            else if (input == Key.Back)
                return "";  // Handle backspace

            // Handle lowercase and special characters.
            bool isShifted = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
            if (input >= Key.A && input <= Key.Z)
            {
                return isShifted ? input.ToString() : input.ToString().ToLower();
            }
            else if (input >= Key.D0 && input <= Key.D9 && !isShifted)
            {
                return input.ToString().Replace("D", "");
            }
            else if (input >= Key.D0 && input <= Key.D9 && isShifted)  // For shifted number keys, ex. !@#$ etc.
            {
                string[] shiftNumChars = { ")", "!", "@", "#", "$", "%", "^", "&", "*", "(" };
                int index = int.Parse(input.ToString().Replace("D", ""));
                return shiftNumChars[index];
            }

            // For other special characters 
            switch (input)
            {
                case Key.OemTilde:
                    return isShifted ? "~" : "`";
                case Key.OemMinus:
                    return isShifted ? "_" : "-";
                case Key.OemPlus:
                    return isShifted ? "+" : "=";
                case Key.OemOpenBrackets:
                    return isShifted ? "{" : "[";
                case Key.OemCloseBrackets:
                    return isShifted ? "}" : "]";
                case Key.OemPipe:
                    return isShifted ? "|" : "\\";
                case Key.OemSemicolon:
                    return isShifted ? ":" : ";";
                case Key.OemQuotes:
                    return isShifted ? "\"" : "'";
                case Key.OemComma:
                    return isShifted ? "<" : ",";
                case Key.OemPeriod:
                    return isShifted ? ">" : ".";
                case Key.OemQuestion:
                    return isShifted ? "?" : "/";
                default:
                    return "";  // Return empty string for unsupported keys.
            }
        }
    }
}