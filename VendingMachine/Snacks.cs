using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class Snacks : Products
    {
        internal int Weight { get; set; }
        internal string WeightSet { get; set; }



        public override void ShowProductSpecifics(string productToExamine, List<Products> listOfProducts)
        {
            bool isProductInfoListed = false;
            foreach (var productitem in listOfProducts)
            {
                if (productToExamine == productitem.ProductName)
                {
                    Console.Write($"Name: {productitem.ProductName}\nInfo about the product: {productitem.ProductInfo}\nNetweight: {(productitem as Snacks).Weight} {(productitem as Snacks).WeightSet}\nPrice: {productitem.ProductPrice}");
                    isProductInfoListed = true;
                }
            }
            if (isProductInfoListed == false)
            {
                Console.WriteLine("Ops! You must have misspelled the item name you would like to look at.");
                Console.ReadKey();
            }
            else
            {
                isProductInfoListed = false;
            }
            Console.ReadKey();
            return;
        }
    }
}