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

namespace ThomasHarper_Cs_Project.Views
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : UserControl
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            
            //validation
            if (tbTaskTitle.Text != "" && tbTaskDescription.Text != "" && tbTaskAssignedTo.Text != "" &&
                tbTaskTitle.Text.Length < 16 && tbTaskDescription.Text.Length < 50 && tbTaskAssignedTo.Text.Length < 15)
            {
                using (var db = new CargoHubEntities())
                {
                    //check whether or not the user exists who we are giving a task to
                    var doesAssigneeExist = db.CargoHubUsers.FirstOrDefault(u => u.UserName == tbTaskAssignedTo.Text);
                    if (doesAssigneeExist != null)
                    {
                        //user does exist so add them to database
                        var taskToAdd = new CargoHubEmployeeTask()
                        {
                            TaskTitle = tbTaskTitle.Text,
                            TaskDescription = tbTaskDescription.Text,
                            TaskAssignedTo = tbTaskAssignedTo.Text,
                            TaskAssignedBy = Data.CurrentUser.UserName
                        };
                        db.CargoHubEmployeeTasks.Add(taskToAdd);
                        db.SaveChanges();
                        MessageBox.Show("Task assigned");
                        tbTaskTitle.Clear();
                        tbTaskDescription.Clear();
                        tbTaskAssignedTo.Clear();
                    }
                    //user does not exist
                    else 
                    {
                        MessageBox.Show("The user who you are trying to assign the task to does not exist", "Error", 
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid input");
            }
        }
    }
}
