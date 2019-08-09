using ProductsWs.Domain.ViewModels;
using System.Collections.Generic;

namespace ProdctsWs.Domain.Services
{
    public interface IProductService
    {
        ProductModel Get(string itemCode);
        List<ProductModel> GetAll();
        void Add(ProductModel model);
        void Update(ProductModel model);
        void Delete(string itemCode);
    }
}
