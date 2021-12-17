using System.Collections.Generic;
using System.Linq;
using CommandPattern.Data.Entities;

namespace CommandPattern.Data.Repos
{
    public class ShopClientRepo: IShopClientRepo
    {
        private Dictionary<string, (Product Product, int Stock)> _products { get; set; }

        public ShopClientRepo()
        {
            _products = new Dictionary<string, (Product Product, int Stock)>();
        }


        public void Add(Product product)
        {
            if (_products.ContainsKey(product.Id))
            {
                IncreaseQuantity(product.Id);
            }
            else
            {
                _products[product.Id] = (product, 1);
            }
        }

        public void IncreaseQuantity(string id)
        {
            if (_products.ContainsKey(id))
            {
                _products[id] = (_products[id].Product, _products[id].Stock+1);
            }
        }

        public void DecreaseQuantity(string id)
        {
            if (_products.ContainsKey(id))
            {
                _products[id] = (_products[id].Product, _products[id].Stock-1);
            }
        }

        public IEnumerable<(Product product, int Quantity)> GetAll() => _products.Select(pair => pair.Value).ToList();

        public (Product product, int Quantity) Get(string id) => _products.Where(x => x.Value.Product.Id == id).Select(pair => pair.Value).FirstOrDefault();

        public void RemoveAll(string id) => _products.Remove(id);
    }
}