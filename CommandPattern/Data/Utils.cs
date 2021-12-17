using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CommandPattern.Data.Entities;
using CommandPattern.Data.Repos;

namespace CommandPattern.Data
{
    public static class Utils
    {
        public static void PrintProducts(IEnumerable<(Product product, int quantity)> productsInCard)
        {
            var productInCards = productsInCard.ToList();
            if (!productInCards.Any())
            {
                Console.WriteLine("Card is empty");
            }
            
            foreach (var productInCard in productInCards)
            {
                Console.WriteLine($"{productInCard.product.Name} : {productInCard.quantity.ToString()}");
            }
        }
    }
}