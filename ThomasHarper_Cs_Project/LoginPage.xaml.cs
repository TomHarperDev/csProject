using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ThomasHarper_Cs_Project
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();

            string test = "hello";

            Hash hashed = test;

            MessageBox.Show(Convert.ToString(hashed));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbUserName.Clear();
            tbPassword.Clear();
            tbUserName.Focus();
        }

        private string Hash()
        {
            string test = "hello";

            int hashed = test.GetHashCode();

            return "";
        }
    }
}
