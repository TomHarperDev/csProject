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
using ThomasHarper_Cs_Project.Views;

namespace ThomasHarper_Cs_Project.Views
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        public void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            //validation
            if (tbNewProductName.Text != "" && tbNewProductCategory.Text != "" && tbNewProductQty.Text != "" &&
                tbNewProductCost.Text != "" && tbNewProductReplenishTime.Text != "")
            {
                try
                {
                    //add in the product to the database and the BST
                    //using (var db = new CargoHubEntities())
                    //{
                    //    var newProduct = new CargoHubProduct()
                    //    {
                    //        ProductName = tbNewProductName.Text,
                    //        ProductCategory = tbNewProductCategory.Text,
                    //        ProductQuantity = Convert.ToInt32(tbNewProductQty.Text),
                    //        ProductCost = Convert.ToDecimal(tbNewProductCost.Text),
                    //        ProductReplenishTime = tbNewProductReplenishTime.Text
                    //    };
                    //    db.CargoHubProducts.Add(newProduct);
                    //    db.SaveChanges();
                    //    MessageBox.Show("Product Added");
                    //}

                    //add in the product to the BST
                    ProductBST.Node nodeToAdd = new ProductBST.Node(
                        Products.products.Count() + 1, 
                        tbNewProductName.Text,        
                        tbNewProductCategory.Text,  
                        Convert.ToInt32(tbNewProductQty.Text), 
                        Convert.ToDecimal(tbNewProductCost.Text), 
                        tbNewProductReplenishTime.Text 
                    );
                    Views.Products.productBST.addProductToTree(Views.Products.productBST.Root , nodeToAdd);
                    Views.Products.products.Add(nodeToAdd);

                }
                catch (Exception ex)
                {
                    //show user error
                    MessageBox.Show("Please ensure all information is in correct format \n The quantity is an integar and cost is a decimal. The rest are strings");
                }
            }
            else
            {
                MessageBox.Show("All fields are required");
            }
            
        }
    }
}
