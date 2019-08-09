using ProdctsWs.Domain.Models;
using System.Collections.Generic;

namespace ProdctsWs.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(string itemCode);
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
