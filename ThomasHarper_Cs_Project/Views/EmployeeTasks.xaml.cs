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
    /// Interaction logic for EmployeeTasks.xaml
    /// </summary>
    public partial class EmployeeTasks : UserControl
    {
        public EmployeeTasks()
        {
            InitializeComponent();
            
            addItemsToGrid();
            
        }
        public void addItemsToGrid()
        {
            using (var db = new CargoHubEntities())
            {
                var items = db.CargoHubEmployeeTasks.ToList();
                TaskDataGrid.ItemsSource = items;
            }
        }

        private void btnTaskDone_Click(object sender, RoutedEventArgs e)
        {
            SubmitTask submitTask = new SubmitTask();
            submitTask.ShowDialog();
        }

        private void btnSearchTask_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CargoHubEntities())
            {
                var items = db.CargoHubEmployeeTasks.ToList();
                TaskDataGrid.ItemsSource = items;
            }
        }
    }
}
