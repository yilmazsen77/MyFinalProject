﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle, sql server, Postgre, Mongo...
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="bardak", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="kamera", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=3, CategoryId=2, ProductName="telefon", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=4, CategoryId=2, ProductName="klavye", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=5, CategoryId=2, ProductName="fare", UnitPrice=15, UnitsInStock=15}
            };
        }   
        
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ Language integrated query
            //Lambda expression

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=>p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderieln ürün id'sine sahip olan ürünü bulur.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            
        }

    }
}
