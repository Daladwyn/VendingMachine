using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    abstract public class Products
    {
        internal string ProductName { get; set; }
        internal int ProductPrice { get; set; }
        internal string ProductInfo { get; set; }
        internal int ProductId { get; set; }
        internal int NumberInInventory { get; set; }
        public string HowToConsume { get; set; }
       
        /// <summary>
        /// Function that lists the available products
        /// </summary>
        /// <param name="listOfProducts"></param>
        public static void Examine(List<Products> listOfProducts)
        {
            foreach (var element in listOfProducts)
            {
                Console.WriteLine($"{element.ProductName,-20}\t{element.ProductInfo} costs {element.ProductPrice}\n ");
            }
        }

        abstract public void ShowProductSpecifics(string productToExamine, List<Products> listOfProducts);

        /// <summary>
        /// This funktion outputs the instructions how to use the purchased products.
        /// </summary>
        /// <param name="whichProductsToConsume is the products that is purchased"></param>
        public static void Use(List<BasketContents> whichProductsToConsume, List<Products> productInstructions)
        {
            whichProductsToConsume.Sort((x, y) => x.BasketProductName.CompareTo(y.BasketProductName));
            foreach (var element in whichProductsToConsume)
            {
                foreach (var instruction in productInstructions)
                {
                    if (element.BasketProductName == instruction.ProductName)
                    {
                        Console.WriteLine($"Instructions for {element.BasketProductName}.\n{instruction.HowToConsume}");
                    }
                }
            }
            Console.ReadKey();
            return;
        }





    }
}