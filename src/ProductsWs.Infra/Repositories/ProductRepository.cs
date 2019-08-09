using ProdctsWs.Domain.Models;
using ProdctsWs.Domain.Repositories;
using ProductsWs.Infra.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace ProductsWs.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductDataContext _context;

        public ProductRepository()
        {
            _context = ProductDataContext.Instance;
        }

        public Product Get(string itemCode)
        {
            return _context.Products.FirstOrDefault(c => itemCode.Equals(c.ItemCode));
        }

        public List<Product> GetAll()
        {
            return _context.Products;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Update(Product product)
        {
            var productDb = Get(product.ItemCode);
            productDb.ItemCode = product.ItemCode;
            productDb.ItemName = product.ItemName;
            productDb.Quantity = product.Quantity;
            productDb.Price = product.Price;
            productDb.CalcTotal();
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }
    }
}
