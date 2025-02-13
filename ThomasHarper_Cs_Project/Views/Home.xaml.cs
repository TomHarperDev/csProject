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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();

            using (var db = new CargoHubEntities())
            {
                //populate the lowest stock item side
                var stockItems = db.CargoHubProducts.ToList();
                int? lowestStock = null;


                string lowestStockName = "";
                string lowestStockCost = "";
                string lowestStockReplenishTime = "";


                //get the product with the least amount of stock left
                foreach (var stockItem in stockItems)
                {
                    if (lowestStock == null)
                    {
                        lowestStock = stockItem.ProductQuantity;
                        lowestStockName = "Name:" + stockItem.ProductName;
                        lowestStockCost = "Cost:" + Convert.ToString(stockItem.ProductCost);
                        lowestStockReplenishTime = "Replenish Time:" + stockItem.ProductReplenishTime;
                    }
                    if (stockItem.ProductQuantity < lowestStock)
                    {
                        lowestStock = stockItem.ProductQuantity;
                        lowestStockName = "Name:" + stockItem.ProductName;
                        lowestStockCost = "Cost:" + Convert.ToString(stockItem.ProductCost);
                        lowestStockReplenishTime = "Replenish Time:" + stockItem.ProductReplenishTime;
                    }
                }
                tbLowestItemName.Text = lowestStockName;
                tbLowestItemCost.Text = lowestStockCost;
                tbLowestItemReplenishTime.Text = lowestStockReplenishTime;


                //populate the task side
                //get task assinged to current user
                var task = db.CargoHubEmployeeTasks.FirstOrDefault(u => u.TaskAssignedTo == Data.CurrentUser.UserName);
                if (task != null)
                {
                    tbTaskTitle.Text = task.TaskTitle;
                }
                else
                {
                    tbTaskTitle.Text = "USER HAS NO TASKS";
                }
            }
        }
    }
}
