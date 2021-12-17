using System;
using System.Collections.Generic;
using System.Linq;
using CommandPattern.Commands;
using CommandPattern.Data;
using CommandPattern.Data.Repos;
using CommandPattern.Enums;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //BasicApproach();
            CommandAproach();
        }

        static void CommandAproach()
        {
            var productRepo = new ProductRepo();
            var shopClientRepo = new ShopClientRepo();

            var product1 = productRepo.FindBy("P1");

            var addToClientCommad1 = new AddToClientCommand(shopClientRepo, productRepo, product1);
            var changeQuantityCommand1 =
                new ChangeQuantityCommand(Operation.Increase, shopClientRepo, productRepo, product1);

            var manager = new CommandManager();
            manager.Invoke(addToClientCommad1);
            manager.Invoke(changeQuantityCommand1);
            
            var product2 = productRepo.FindBy("P2");

            var addToClientCommad2 = new AddToClientCommand(shopClientRepo, productRepo, product2);
            var changeQuantityCommand2 =
                new ChangeQuantityCommand(Operation.Increase, shopClientRepo, productRepo, product2);
            
            manager.Invoke(addToClientCommad2);
            manager.Invoke(changeQuantityCommand2);
            manager.Invoke(changeQuantityCommand2);
            manager.Invoke(changeQuantityCommand2);

            Utils.PrintProducts(shopClientRepo.GetAll());
        }

        static void BasicApproach()
        {
            var productRepo = new ProductRepo();
            var shopClientRepo = new ShopClientRepo();

            var product1 = productRepo.FindBy("P1");
            shopClientRepo.Add(product1);
            shopClientRepo.IncreaseQuantity(product1.Id);
            
            var product2 = productRepo.FindBy("P2");
            
            shopClientRepo.Add(product2);
            shopClientRepo.IncreaseQuantity(product2.Id);
            shopClientRepo.IncreaseQuantity(product2.Id);
            shopClientRepo.IncreaseQuantity(product2.Id);
            
            Utils.PrintProducts(shopClientRepo.GetAll());
        }
    }
}