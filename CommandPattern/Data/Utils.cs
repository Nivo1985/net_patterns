using System;
using System.Collections;
using System.Collections.Generic;
using CommandPattern.Data.Entities;
using CommandPattern.Data.Repos;

namespace CommandPattern.Data
{
    public static class Utils
    {
        public static void PrintProducts(IEnumerable<(Product product, int quantity)> productsInCard)
        {
            foreach (var productInCard in productsInCard)
            {
                Console.WriteLine($"{productInCard.product.Name} : {productInCard.quantity.ToString()}");
            }
        }
    }
}