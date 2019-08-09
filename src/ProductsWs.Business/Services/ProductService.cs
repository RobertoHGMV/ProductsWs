using ProdctsWs.Domain.Models;
using ProdctsWs.Domain.Repositories;
using ProdctsWs.Domain.Services;
using ProductsWs.Domain.ViewModels;
using ProductsWs.Infra.Repositories;
using System;
using System.Collections.Generic;

namespace ProductsWs.Business.Services
{
    public class ProductService : IProductService
    {
        IProductRepository _repository;

        public ProductService()
        {
            _repository = new ProductRepository();
        }

        public ProductModel Get(string itemCode)
        {
            var product = _repository.Get(itemCode);
            return CreateModel(product);
        }

        public List<ProductModel> GetAll()
        {
            var products = _repository.GetAll();
            return CreateModels(products);
        }

        public void Add(ProductModel model)
        {
            var product = CreateProduct(model);
            _repository.Add(product);
        }

        public void Update(ProductModel model)
        {
            var productDb = _repository.Get(model.ItemCode);

            if (productDb is null)
                throw new Exception($"Produto com código {model.ItemCode} não encontrado!");

            var product = CreateProduct(model);
            _repository.Update(product);
        }

        public void Delete(string itemCode)
        {
            var product = _repository.Get(itemCode);
            _repository.Delete(product);
        }

        private Product CreateProduct(ProductModel model)
        {
            var product = new Product();
            product.ItemCode = model.ItemCode;
            product.ItemName = model.ItemName;
            product.Quantity = model.Quantity;
            product.Price = model.Price;
            product.CalcTotal();
            return product;
        }

        private ProductModel CreateModel(Product product)
        {
            var model = new ProductModel();
            model.ItemCode = product.ItemCode;
            model.ItemName = product.ItemName;
            model.Quantity = product.Quantity;
            model.Price = product.Price;
            model.Total = product.Total;
            return model;
        }

        private List<ProductModel> CreateModels(List<Product> products)
        {
            var models = new List<ProductModel>();

            foreach (var product in products)
                models.Add(CreateModel(product));

            return models;
        }
    }
}
