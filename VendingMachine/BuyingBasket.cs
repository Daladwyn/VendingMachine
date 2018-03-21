using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class BuyingBasket
    {
        internal int BasketId { get; private set; }
        internal List<BasketContents> MyBasketContents = new List<BasketContents>();  //contains Productname, NumberOfItems, PricePerProduct 
        internal int BasketTotalPrice { get; private set; }

        public BuyingBasket()
        {
            BasketId = 0;
            BasketTotalPrice = 0;
        }
        /// <summary>
        /// This function lets the user add a product and amount of that item to buying basket
        /// </summary>
        /// <param name="chosenProduct is the name of the product to be added."></param>
        /// <param name="amount is the number of items to be added."></param>
        /// <param name="products is the list of products that is available."></param>
        /// <param name="contents is a list that the product is to be added to."></param>
        /// <returns></returns>
        public BasketContents AddProductToBasket(string chosenProduct, int amount, List<Products> products, List<BasketContents> contents)
        {
            BasketContents itemToAdd = new BasketContents();
            itemToAdd.BasketProductName = chosenProduct;
            foreach (var element in products)
                if (chosenProduct == element.ProductName)
                {
                    itemToAdd.BasketProductPrice = element.ProductPrice;
                }
            itemToAdd.BasketNumberOfItems = amount;
            itemToAdd.BasketTotalProductPrice = itemToAdd.BasketProductPrice * itemToAdd.BasketNumberOfItems;
            return (itemToAdd);
        }
        /// <summary>
        /// This function calculates the value of the basket
        /// </summary>
        /// <param name="contents is a list of products that is added."></param>
        /// <returns></returns>
        public int BasketValue(List<BasketContents> contents)
        {
            BasketTotalPrice = 0;
            foreach (var element in contents)
            {
                element.BasketTotalProductPrice = element.BasketProductPrice * element.BasketNumberOfItems;
                Console.WriteLine($"{element.BasketProductName,-20}{element.BasketNumberOfItems,-10}{element.BasketProductPrice,-10}{element.BasketTotalProductPrice,-10}");
                BasketTotalPrice = BasketTotalPrice + element.BasketTotalProductPrice;
            }
            return BasketTotalPrice;
        }

        /// <summary>
        /// This function calulates the amount of change and which notes/coins to be returned.
        /// </summary>
        /// <param name="remainingChange"></param>
        public void Purchase(int remainingChange)
        {
            {
                int[] moneyDenomination = new int[8] { 1, 5, 10, 20, 50, 100, 500, 1000 };
                int arrayIndex = 7;
                Console.WriteLine($"Your change is {remainingChange} SEK.");
                do
                {
                    if (remainingChange >= moneyDenomination[arrayIndex])
                    {
                        Console.WriteLine($"You recive a {moneyDenomination[arrayIndex]} note/coin.");
                        remainingChange = remainingChange - moneyDenomination[arrayIndex];
                    }
                    else
                    {
                        arrayIndex--;
                    }
                } while (remainingChange > 0);
                Console.WriteLine("Please hit any key to continue.");
                Console.ReadKey();
            }
        }
        /// <summary>
        /// This function lists the products the user so far have added
        /// </summary>
        /// <param name="contents is the list of items that have been added."></param>
        /// <returns></returns>
        public int ShowBasket(List<BasketContents> contents)
        {
            Console.Clear();
            BasketTotalPrice = 0;
            Console.WriteLine($"Your basket contains the following items:\n");
            Console.WriteLine($"Name{"",-16}Amount{"",-4}Price{"",-5}Total Price{"",-5}");
            foreach (var element in contents)
            {
                element.BasketTotalProductPrice = element.BasketProductPrice * element.BasketNumberOfItems;
                Console.WriteLine($"{element.BasketProductName,-20}{element.BasketNumberOfItems,-10}{element.BasketProductPrice,-10}{element.BasketTotalProductPrice,-10}");
                BasketTotalPrice = BasketTotalPrice + element.BasketTotalProductPrice;
            }
            Console.WriteLine($"Total Price is: {BasketTotalPrice}");
            Console.WriteLine("\nPlease hit any key to continue");
            Console.ReadKey();
            return BasketTotalPrice;
        }
    }
}