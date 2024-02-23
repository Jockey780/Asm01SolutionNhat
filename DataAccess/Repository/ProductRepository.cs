using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetProducts() => ProductDAO.Instance.GetProducts();
        public void AddProduct(Product product) => ProductDAO.Instance.AddProduct(product);
    }
}
