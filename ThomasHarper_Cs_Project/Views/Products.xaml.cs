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
using ThomasHarper_Cs_Project.Data;

namespace ThomasHarper_Cs_Project.Views
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : UserControl
    {
        public string toms;
        public Products()
        {
            InitializeComponent();
            addItemsToGrid();

        }
        public void addItemsToGrid()
        {
            using (var db = new CargoHubEntities())
            {
                var items = db.CargoHubProducts.ToList();
                ProductDataGrid.ItemsSource = items;
            }
        }

        private void btnSearchProduct_Click(object sender, RoutedEventArgs e)
        {
            //validation
            if (tbProductSearch.Text.Length < 16)
            {
                ProductBST productBST = new ProductBST();
                ProductBST.Node search = productBST.TraverseProductTree(productBST.Root,tbProductSearch.Text);

                if (search != null)
                {
                    ViewProduct viewProduct = new ViewProduct();
                    viewProduct.tbProductID.Text = Convert.ToString(search.Id);
                    viewProduct.tbProductName.Text = search.ProductName;
                    viewProduct.tbProductCategory.Text = search.ProductCategory;
                    viewProduct.tbProductQty.Text = Convert.ToString(search.ProductQty);
                    viewProduct.tbProductCost.Text = Convert.ToString(search.ProductCost);
                    viewProduct.tbProductReplenishTime.Text = search.ProductReplenishTime;
                    viewProduct.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Product does not exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Product cannot exist as input is too long");
            }
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //validation
                if (tbSearchID.Text.Length < 16 && tbSearchID.Text != "" && (tbSearchID.Text.All(char.IsDigit)))
                {
                    //need to reset the fields in the currentUser to null
                    productNode.Id = null;
                    productNode.ProductName = null;
                    productNode.ProductCategory = null;
                    productNode.ProductQty = null;
                    productNode.ProductCost = null;
                    productNode.ProductReplenishTime = null;

                    EditProduct editProduct = new EditProduct();

                    using (var db = new CargoHubEntities())
                    {
                        int searchId = Convert.ToInt32(tbSearchID.Text);
                        var productToBeEdited = db.CargoHubProducts.FirstOrDefault(u => u.ProductID == searchId);
                        editProduct.tbProductId.Text = tbSearchID.Text;
                        editProduct.tbNewProductName.Text = productToBeEdited.ProductName;
                        editProduct.tbNewProductCategory.Text = productToBeEdited.ProductCategory;
                        editProduct.tbNewProductQty.Text = Convert.ToString(productToBeEdited.ProductQuantity);
                        editProduct.tbNewProductCost.Text = Convert.ToString(Convert.ToDouble(productToBeEdited.ProductCost));
                        editProduct.tbNewProductReplenishTime.Text = productToBeEdited.ProductReplenishTime;
                        editProduct.ShowDialog();
                        addItemsToGrid();
                    }
                }
                else
                {
                    MessageBox.Show("Input must be an integar ");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
            addItemsToGrid();

            
            
        }
    }
}
