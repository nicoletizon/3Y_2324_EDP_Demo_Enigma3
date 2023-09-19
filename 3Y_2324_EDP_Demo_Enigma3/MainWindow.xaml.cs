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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool initialState = true;
        string defaultMessage = "Just type whatever...";

        public MainWindow()
        {
            InitializeComponent();

            if(initialState)
                lblInput.Content = defaultMessage;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if(initialState) 
            {
                initialState = false;
                lblInput.Content = KeyManager(e.Key);
            }
            else
                lblInput.Content += KeyManager(e.Key) + "";
        }

        private char KeyManager(Key input)
        {
            char retVal = ' ';

            if (input == Key.Space)
                retVal = ' ';
            else
                retVal = input.ToString()[0];

            return retVal;
        }
    }
}
