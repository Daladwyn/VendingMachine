using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class BuyingBasket
    {
        private int BasketId;
        private List<string> BasketContents;//contains Productname, NumberOfItems, PricePerProduct and TotalPriceForItems
        private int BasketTotalPrice;

        public void Purchase()
        {
            throw new System.NotImplementedException();
        }

        public void ShowBasketContents()
        {
            Console.WriteLine($"Your basket contains the following items:\n");
            foreach (var element in BasketContents)
            {
                Console.WriteLine(element,"\t");
               // if(element == 3
                    
                    //("4"||"8"||"12"||"16"||"20"||"24"||"28"||"32"||"36"||"40"))
            }
            Console.WriteLine($"Total Price is: {BasketTotalPrice}");
        }
    }
}