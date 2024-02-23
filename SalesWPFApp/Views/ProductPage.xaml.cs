using BusinessObject.Models;
using Service;
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

namespace SalesWPFApp.Views
{
    /// <summary>
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : UserControl
    {
        private IProductService productService;

        public ProductPage()
        {
            InitializeComponent();
            productService = new ProductService();
            loadProductData();
        }

        private void loadProductData()
        {
            // Gọi phương thức GetProducts từ ProductService để lấy danh sách sản phẩm
            List<Product> productList = productService.GetProducts();

            // Gán danh sách sản phẩm vào ItemsSource của DataGrid
            dtg_Product.ItemsSource = productList;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dtg_Product.SelectedItem != null)
            {
                Product selectedData = (Product)dtg_Product.SelectedItem;

                txt_ProductId.Text = selectedData.ProductId.ToString();
                txt_CategoryId.Text = selectedData.Category.ToString();
                txt_ProductName.Text = selectedData.ProductName.ToString();
                txt_UnitPrice.Text = selectedData.UnitPrice.ToString();
                txt_Quantity.Text = selectedData.Quantity.ToString();

            }
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txt_ProductId.Text, out int productId) &&
        int.TryParse(txt_CategoryId.Text, out int categoryId) &&
        decimal.TryParse(txt_UnitPrice.Text, out decimal unitPrice) &&
        int.TryParse(txt_Quantity.Text, out int quantity))
            {
                // Tạo đối tượng Product từ thông tin lấy được
                Product newProduct = new Product
                {
                    ProductId = productId,
                    Category = categoryId,
                    ProductName = txt_ProductName.Text,
                    UnitPrice = unitPrice,
                    Quantity = quantity
                };

                productService.AddProduct(newProduct);

                RefreshDataGrid();

            }
            else
            {
                MessageBox.Show("Invalid input. Please check the entered values.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshDataGrid()
        {
            // Làm mới DataGrid để hiển thị sản phẩm mới thêm vào
            dtg_Product.ItemsSource = productService.GetProducts();
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            txt_ProductId.Clear();
            txt_CategoryId.Clear();
            txt_ProductName.Clear();
            txt_UnitPrice.Clear();
            txt_Quantity.Clear();
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_Product.SelectedItem != null)
            {
                // Lấy sản phẩm đã chọn từ DataGrid
                Product selectedProduct = (Product)dtg_Product.SelectedItem;

                // Cập nhật thông tin từ TextBox vào sản phẩm đã chọn
                selectedProduct.Category = int.Parse(txt_CategoryId.Text);
                selectedProduct.ProductName = txt_ProductName.Text;
                selectedProduct.UnitPrice = decimal.Parse(txt_UnitPrice.Text);
                selectedProduct.Quantity = int.Parse(txt_Quantity.Text);

                // Gọi phương thức EditProduct từ ProductService để lưu thay đổi
                productService.UpdateProduct(selectedProduct);

                // Cập nhật lại danh sách sản phẩm trong DataGrid
                RefreshDataGrid();
            }
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_Product.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Product selectedData = (Product)dtg_Product.SelectedItem;

                    productService.DeleteProduct(selectedData);

                    RefreshDataGrid();
                }
            }
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txt_Search.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu TextBox tìm kiếm trống, hiển thị toàn bộ sản phẩm
                RefreshDataGrid();
            }
            else
            {
                // Kiểm tra xem keyword có phải là một số không
                if (int.TryParse(keyword, out int categoryId))
                {
                    // Nếu keyword là một số, lọc danh sách sản phẩm theo CategoryId
                    List<Product> filteredProducts = productService.GetProducts().Where(p =>
                        p.Category == categoryId
                    ).ToList();

                    dtg_Product.ItemsSource = filteredProducts;
                }
                else
                {
                    // Nếu không phải là số, thực hiện tìm kiếm theo các trường khác
                    List<Product> filteredProducts = productService.GetProducts().Where(p =>
                        p.ProductName.ToLower().Contains(keyword) ||
                        p.UnitPrice.ToString().ToLower().Contains(keyword) ||
                        p.Quantity.ToString().ToLower().Contains(keyword)
                    ).ToList();

                    dtg_Product.ItemsSource = filteredProducts;
                }
            }
        }
    }
}
