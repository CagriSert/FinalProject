using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 150, UnitsInStock = 123 },
                new Product{ ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 15, UnitsInStock = 113 },
                new Product{ ProductId = 3, CategoryId = 2, ProductName = "Monitor", UnitPrice = 15, UnitsInStock = 3 },
                new Product{ ProductId = 7, CategoryId = 2, ProductName = "Kulaklı", UnitPrice = 144, UnitsInStock = 12 },
                new Product{ ProductId = 7, CategoryId = 2, ProductName = "Klavyer", UnitPrice = 125, UnitsInStock = 13 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete =  _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return  _products.Where(x => x.CategoryId == categoryId).ToList();

        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
