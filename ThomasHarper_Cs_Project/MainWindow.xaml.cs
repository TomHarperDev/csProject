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
using ThomasHarper_Cs_Project.Models;
using ThomasHarper_Cs_Project.Views;



namespace ThomasHarper_Cs_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            addDataToDatabase();
            parentGrid.Children.Clear();
            Home home = new Home();
            parentGrid.Children.Add(home);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Data.CurrentUser.UserName = string.Empty;
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        private void btnTask_Click(object sender, RoutedEventArgs e)
        {
            parentGrid.Children.Clear();
            Views.EmployeeTasks newTask = new Views.EmployeeTasks();
            parentGrid.Children.Add(newTask);
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            // only allow user access to this page if the user is an admin
            try
            {
                using (var db = new CargoHubEntities())
                {
                    var isUserAdmin = db.CargoHubUsers.FirstOrDefault(u => u.UserName == Data.CurrentUser.UserName).IsUserAdmin;
                    if (isUserAdmin == true)
                    {
                        parentGrid.Children.Clear();
                        Views.Admin admin = new Views.Admin();
                        parentGrid.Children.Add(admin);
                    }
                    else
                    {
                        MessageBox.Show("You do not have permission to this page", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
            //user isnt an admin
            catch (Exception)
            {
                MessageBox.Show("You do not have permission to this page", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            parentGrid.Children.Clear();
            Products products = new Products();
            parentGrid.Children.Add(products);
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            parentGrid.Children.Clear();
            Home home = new Home();
            parentGrid.Children.Add(home);
        }


        public void addDataToDatabase()
        {
            using (var db = new CargoHubEntities())
            {
                //add a task
                var newTask = new CargoHubEmployeeTasks()
                {
                    TaskTitle = "Update",
                    TaskDescription = "Update price: £10.00",
                    TaskAssignedTo = "admin",
                    TaskAssignedBy = "admin"
                };
                db.CargoHubEmployeeTasks.Add(newTask);

                db.SaveChanges();


                //add a product for the task to be completed on
                var newProduct = new CargoHubProducts()
                {
                    ProductName = "Headphones",
                    ProductCategory = "Electronics",
                    ProductQuantity = 54,
                    ProductCost = 15.00m,
                    ProductReplenishTime = "1 week"
                };
                db.CargoHubProducts.Add(newProduct);


                db.SaveChanges();

            }
        }
    }
}
