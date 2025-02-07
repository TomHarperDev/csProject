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
using System.Windows.Shapes;

namespace ThomasHarper_Cs_Project.Views
{
    /// <summary>
    /// Interaction logic for SubmitTask.xaml
    /// </summary>
    public partial class SubmitTask : Window
    {
        public SubmitTask()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CargoHubEntities())
            {
                int ID = Convert.ToInt32(tbTaskID.Text);
                var itemToRemove = db.CargoHubEmployeeTasks.FirstOrDefault(u => u.TaskID == ID);
                db.CargoHubEmployeeTasks.Remove(itemToRemove);
                db.SaveChanges();
            }
        }
    }
}
