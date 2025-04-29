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
using ThomasHarper_Cs_Project.Data;
using ThomasHarper_Cs_Project.Models;

namespace ThomasHarper_Cs_Project.Views
{
    /// <summary>
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        public EditProduct()
        {
            InitializeComponent();
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            //validate all inputs
            if (tbNewProductName.Text != null && tbNewProductCategory.Text != null && tbNewProductQty.Text != null && tbNewProductCost.Text != null && tbNewProductReplenishTime != null &&
                tbNewProductName.Text.Length < 16 && tbNewProductCategory.Text.Length < 16 && tbNewProductReplenishTime.Text.Length <16)
            {
                using (var db = new CargoHubEntities())
                {
                    //find product to be edited
                    int prodID = Convert.ToInt32(tbProductId.Text);
                    var editedProduct = db.CargoHubProducts.FirstOrDefault(u => u.ProductID == prodID);
                    //update the fields based on the windows inputs
                    editedProduct.ProductName = tbNewProductName.Text;
                    editedProduct.ProductCategory = tbNewProductCategory.Text;
                    editedProduct.ProductQuantity = Convert.ToInt32(tbNewProductQty.Text);
                    editedProduct.ProductCost = Convert.ToDecimal(tbNewProductCost.Text);
                    editedProduct.ProductReplenishTime = tbNewProductReplenishTime.Text;

                    db.SaveChanges();
                    this.Close();
                }
            }
        }
    }
}
