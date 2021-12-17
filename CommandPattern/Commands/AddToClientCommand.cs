using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using CommandPattern.Data.Entities;
using CommandPattern.Data.Repos;

namespace CommandPattern.Commands
{
    public class AddToClientCommand: ICommand
    {
        private readonly IShopClientRepo _shopClientRepo;
        private readonly IProductRepo _productRepo;
        private readonly Product _product;

        public AddToClientCommand(IShopClientRepo shopClientRepo, IProductRepo productRepo, Product product)
        {
            _shopClientRepo = shopClientRepo;
            _productRepo = productRepo;
            _product = product;
        }
        
        public void Do()
        {
            if (_product != null)
            {
                _productRepo.DecreaseStockBy(_product.Id, 1);
                _shopClientRepo.Add(_product);   
            }
        }

        public bool CanDo()
        {
            if (_product == null) return false;

            return _productRepo.GetStockFor(_product.Id) > 0;
        }

        public void Undo()
        {
            if (_product == null) return;

            var tempProduct = _shopClientRepo.Get(_product.Id);
            if (tempProduct.product == null) return;
            
            _productRepo.IncreaseStockBy(tempProduct.product.Id, tempProduct.Quantity);
            _shopClientRepo.RemoveAll(tempProduct.product.Id);
        }
    }
}