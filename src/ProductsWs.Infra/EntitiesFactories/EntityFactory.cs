using ProdctsWs.Domain.Models;
using System;
using System.Collections.Generic;

namespace ProductsWs.Infra.EntitiesFactories
{
    public class EntityFactory
    {
        public List<Product> CreateProducts()
        {
            var number = new Random();
            var products = new List<Product>();

            for (var i = 1; i <= 20; i++)
            {
                var id = number.Next(1, 100);
                var product = new Product();
                product.ItemCode = $"I00{id}";
                product.ItemName = $"Item número {id}";
                product.Quantity = number.Next(1, 100);
                product.Price = number.Next(50, 10000);
                product.CalcTotal();
                products.Add(product);
            }

            return products;
        }
    }
}
