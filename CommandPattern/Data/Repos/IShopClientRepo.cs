using System.Collections.Generic;
using CommandPattern.Data.Entities;

namespace CommandPattern.Data.Repos
{
    public interface IShopClientRepo
    {
        void Add(Product product);

        void IncreaseQuantity(string id);
        
        void DecreaseQuantity(string id);

        IEnumerable<(Product product, int Quantity)> GetAll();

        (Product product, int Quantity) Get(string id);

        void RemoveAll(string id);
    }
}