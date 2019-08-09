using ProdctsWs.Domain.Models;
using ProductsWs.Infra.EntitiesFactories;
using System.Collections.Generic;

namespace ProductsWs.Infra.Contexts
{
    public class ProductDataContext
    {
        static ProductDataContext _instance;

        private ProductDataContext()
        {
            Products = new EntityFactory().CreateProducts();
        }

        public static ProductDataContext Instance
        {
            get { return GetInstance(); }
        }

        private static ProductDataContext GetInstance()
        {
            if (_instance is null)
                _instance = new ProductDataContext();

            return _instance;
        }

        public List<Product> Products { get; set; }
    }
}
