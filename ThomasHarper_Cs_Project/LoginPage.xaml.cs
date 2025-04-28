using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using ThomasHarper_Cs_Project.Models;
using ThomasHarper_Cs_Project.Views;
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


            //add a user to db
            using (var db = new CargoHubEntities())
            {
                var newUser = new CargoHubUsers()
                {
                    UserID = 1,
                    UserName = "admin",
                    UserPassword = "e7cf3ef4f17c3999a94f2c6f612e8a888e5b1026878e4e19398b23bd38ec221a",
                    IsUserAdmin = true
                };
                db.CargoHubUsers.Add(newUser);
                db.SaveChanges();
                MessageBox.Show($"User Added {newUser.UserName} : {newUser.UserPassword}");
            }
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
                try
                {
                    using (var database = new CargoHubEntities())
                    {

                        //var databaseQuery = database.CargoHubUsers.FirstOrDefault(user => user.UserName == tbUserName.Text );

                        var databaseQuery = database.CargoHubUsers.FirstOrDefault(user => user.UserName == tbUserName.Text
                        && user.UserPassword == hashedPassword);

                        if (databaseQuery != null)
                        {
                            //ADDED IN TO ALLOW USERNAME TO BE STORED FOR ADMIN PAGE
                            Data.CurrentUser.UserName = tbUserName.Text;

                            //once the user has been logged in, redirect them
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }
            }
            else
            {
                MessageBox.Show("Userame must be less than 16 characters \nPassword must be less than 16 characters and have one uppercase character",
                    "Credentials entered are invalid", MessageBoxButton.OK, MessageBoxImage.Error);
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
