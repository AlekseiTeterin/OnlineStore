﻿using System.Collections.Concurrent;

namespace OnlineStore
{
    public interface ICatalog
    {
        void AddProduct(Product product);
        ConcurrentBag<Product> GetProducts();
        void DeleteProduct(int id);
    }
}