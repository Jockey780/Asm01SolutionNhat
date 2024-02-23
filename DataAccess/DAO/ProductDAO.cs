using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private readonly SalesManagementContext dbContext = null;

        private ProductDAO()
        {
            dbContext = new SalesManagementContext();
        }

        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductDAO();
                }
                return instance;
            }
        }
        public List<Product> GetProducts()
        {
            return dbContext.Products.ToList();
        }

        public void AddProduct(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            var existingProduct = dbContext.Products.Find(product.ProductId);
            if (existingProduct != null)
            {
                // Update thông tin của sản phẩm
                existingProduct.Category = product.Category;
                existingProduct.ProductName = product.ProductName;
                existingProduct.UnitPrice = product.UnitPrice;
                existingProduct.Quantity = product.Quantity;

                dbContext.SaveChanges();
            }
        }
        public void DeleteProduct(Product product)
        {
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
        }
    }
}
