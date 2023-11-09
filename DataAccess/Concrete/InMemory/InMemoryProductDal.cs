using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle, sql server, mongoDb
            _products = new List<Product> { 
                new Product {CategoryId = 1, ProductId = 1, ProductName="Bardak", UnitsInStock=15, UnitPrice=15},
                new Product {CategoryId = 2, ProductId = 1, ProductName="Kamera", UnitsInStock=3, UnitPrice=500},
                new Product {CategoryId = 3, ProductId = 2, ProductName="Telefon", UnitsInStock=2, UnitPrice=1500},
                new Product {CategoryId = 4, ProductId = 2, ProductName="Klavye", UnitsInStock=65, UnitPrice=150},
                new Product {CategoryId = 5, ProductId = 2, ProductName="Fare", UnitsInStock=1, UnitPrice=85},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ Language Integrated Queue
            //Lambda
            Product productToDelete=_products.SingleOrDefault(p=>p.ProductId == product.ProductId);
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

        public List<Product> GetAllByCategory(int CategoryId)
        {
            return _products.Where(p => p.CategoryId == CategoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName= product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice= product.UnitPrice;
            productToUpdate.UnitsInStock= product.UnitsInStock;
            
        }
    }
}
