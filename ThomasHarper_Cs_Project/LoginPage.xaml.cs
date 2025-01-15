using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
using static System.Net.Mime.MediaTypeNames;

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
        }

        private bool usernameValidation()
        {
            if (tbUserName.Text.Length <= 15)
            {
                return true;
            }
            return false;
        }

        private bool passwordValidation()
        {
            //whilst the database stores passwords at a length of 64 characters, this is only after being hashed so the user just needs to enter in a suitable password length
            if (tbPassword.Password.Length <= 15)
            {
                if (tbPassword.Password.Any(char.IsUpper))
                {
                    return true;
                }
            }
            return false;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string unHashedPassword = tbPassword.Password;
            string hashedPassword = Hash(unHashedPassword);

            if (usernameValidation() && passwordValidation())
            {
                // code to log the user in
                using (var database = new Entities())
                {
                    var databaseQuery = database.tblUsers.FirstOrDefault(user => user.UserName == tbUserName.Text
                    && user.Password == Hash(tbPassword.Password));

                    if (!databaseQuery == null)
                    {
                        //once the user has been logged in, redirect them
                        this.Close();
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();

                    }
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbUserName.Clear();
            tbPassword.Clear();
            tbUserName.Focus();
        }

        private string Hash(string message)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(message));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
