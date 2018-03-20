using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class Drinks : Products
    {
        internal int Temperature { get; set; }
        internal int Volume { get; set; }
        internal string VolumeSet { get; set; }




        public override void ShowProductSpecifics(string productToExamine, List<Products> listOfProducts)
        {
            bool isProductInfoListed = false;
            foreach (var productitem in listOfProducts)
            {
                if (productToExamine == productitem.ProductName)
                {
                    Console.Write($"Name: {productitem.ProductName}\nInfo about the product: {productitem.ProductInfo}\nServing temperature : {(productitem as Drinks).Temperature} degrees\nVolume: {(productitem as Drinks).Volume} {(productitem as Drinks).VolumeSet}\nPrice: {productitem.ProductPrice}");
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