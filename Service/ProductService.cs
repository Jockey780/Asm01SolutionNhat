using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;

        public ProductService()
        {
            productRepository = new ProductRepository();
        }

        public List<Product> GetProducts()
        {
            return productRepository.GetProducts();
        }

        public void AddProduct(Product product)
        {
            productRepository.AddProduct(product);
            List<Product> updatedProducts = productRepository.GetProducts();

        }

        public void UpdateProduct(Product product)
        {
            productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            productRepository.DeleteProduct(product);
        }
    }
}
