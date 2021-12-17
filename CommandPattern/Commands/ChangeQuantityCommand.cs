using System;
using CommandPattern.Data.Entities;
using CommandPattern.Data.Repos;
using CommandPattern.Enums;

namespace CommandPattern.Commands
{
    public class ChangeQuantityCommand: ICommand
    {
        private Operation _operation;
        private IShopClientRepo _shopClientRepo;
        private IProductRepo _productRepo;
        private Product _product;

        public ChangeQuantityCommand(Operation operation, IShopClientRepo shopClientRepo, IProductRepo productRepo,Product product)
        {
            _operation = operation;
            _product = product;
            _productRepo = productRepo;
            _shopClientRepo = shopClientRepo;
        }
        
        public void Do()
        {
            switch (_operation)
            {
                case Operation.Decrease:
                    _productRepo.IncreaseStockBy(_product.Id, 1);
                    _shopClientRepo.DecreaseQuantity(_product.Id);
                    break;
                case Operation.Increase:
                    _productRepo.DecreaseStockBy(_product.Id, 1);
                    _shopClientRepo.IncreaseQuantity(_product.Id);
                    break;
            }
        }

        public bool CanDo()
        {
            return _operation switch
            {
                Operation.Decrease => _shopClientRepo.Get(_product.Id).Quantity > 0,
                Operation.Increase => _productRepo.GetStockFor(_product.Id) > 0,
                _ => false
            };
        }

        public void Undo()
        {
            switch (_operation)
            {
                case Operation.Decrease:
                    _productRepo.DecreaseStockBy(_product.Id, 1);
                    _shopClientRepo.IncreaseQuantity(_product.Id);
                    break;
                case Operation.Increase:
                    _productRepo.IncreaseStockBy(_product.Id, 1);
                    _shopClientRepo.DecreaseQuantity(_product.Id);
                    break;
            }
        }
    }
}