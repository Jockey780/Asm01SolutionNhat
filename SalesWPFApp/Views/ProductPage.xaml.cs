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
                    // Các thuộc tính khác...
                };

                // Gọi phương thức thêm sản phẩm từ ProductService
                productService.AddProduct(newProduct);

                // Làm mới DataGrid để hiển thị sản phẩm mới thêm vào
                RefreshDataGrid();

                // Optional: Xóa dữ liệu trên TextBox sau khi thêm thành công
                ClearTextBoxes();
            }
            else
            {
                // Hiển thị thông báo lỗi nếu đầu vào không hợp lệ
                MessageBox.Show("Invalid input. Please check the entered values.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshDataGrid()
        {
            // Làm mới DataGrid để hiển thị sản phẩm mới thêm vào
            dtg_Product.ItemsSource = productService.GetProducts();
        }

        private void ClearTextBoxes()
        {
            // Xóa dữ liệu trên TextBox
            txt_ProductId.Clear();
            txt_CategoryId.Clear();
            txt_ProductName.Clear();
            txt_UnitPrice.Clear();
            txt_Quantity.Clear();
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
