using System;
using System.Collections.Generic;
using System.Linq;
using CommandPattern.Data.Entities;

namespace CommandPattern.Data.Repos
{
    public class ProductRepo: IProductRepo
    {
        private Dictionary<string, (Product Product, int Stock)> products { get; set; }

        public ProductRepo()
        {
            products = new Dictionary<string, (Product Product, int Stock)>();
            
            Add(new Product("P1", "Prod 1", 110), 2);
            Add(new Product("P2", "Prod 2", 120), 4);
            Add(new Product("P3", "Prod 3", 130), 6);
        }
        

        public void Add(Product product, int stock) => products[product.Id] = (product, stock);

        public Product FindBy(string id) => !products.ContainsKey(id) ? null : products[id].Product;

        public int GetStockFor(string id) => !products.ContainsKey(id) ? 0 : products[id].Stock;

        public IEnumerable<Product> GetAll() => products.Select(keyValuePair => keyValuePair.Value.Product).ToList();

        public void DecreaseStockBy(string id, int amount)
        {
            if (products.ContainsKey(id))
            {
                products[id] = (products[id].Product, products[id].Stock - amount);
            }
        }

        public void IncreaseStockBy(string id, int amount)
        {
            if (products.ContainsKey(id))
            {
                products[id] = (products[id].Product, products[id].Stock + amount);
            }
        }
    }
}