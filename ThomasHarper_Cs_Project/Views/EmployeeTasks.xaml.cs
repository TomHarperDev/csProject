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
            //to perform a binary search i need to sort the items, but i need to sort them based 
            // on a specific property
             //https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
                var items = db.CargoHubEmployeeTasks.ToList();
                items.OrderBy(u => u.TaskTitle).ToList();


                //with the item now sorted they can be searched through using a binary search
                int foundID = items.FindAll(u => u.TaskTitle == "hg").BinarySearch(tbNameSearch.Text);
            }
        }
    }
}
