using System.Collections.Generic;
using CommandPattern.Data.Entities;

namespace CommandPattern.Data.Repos
{
    public interface IProductRepo
    {
        void Add(Product product, int stock);
        Product FindBy(string id);
        int GetStockFor(string id);
        IEnumerable<Product> GetAll();
        void DecreaseStockBy(string id, int amount);
        void IncreaseStockBy(string id, int amount);
    }
}
