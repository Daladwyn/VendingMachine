using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Fruits Banana = new Fruits { ProductName = "Banana", ProductPrice = 5, ProductInfo = "A yellow 15 cm slightly curved fruit\t", ProductId = 1, HowToConsume = "You have to peel this fruit." };
            Fruits Apple = new Fruits { ProductName = "Golden Delisious", ProductPrice = 6, ProductInfo = "A yellov-green apple.\t\t\t", ProductId = 2, HowToConsume = "You have to wash this fruit before eating it." };
            Drinks Coffee = new Drinks { ProductName = "Black Coffee", ProductPrice = 19, ProductInfo = "Coffee made from medium roasted beans.\t", ProductId = 3, Temperature = 40, Volume = 2, VolumeSet = "dl", HowToConsume = "Beware! This product could be warm to the touch." };
            Drinks CokaCola = new Drinks { ProductName = "Coka Cola", ProductPrice = 14, ProductInfo = "Coka-cola from the Coka-Cola Company.\t", ProductId = 4, Temperature = 5, Volume = 2, VolumeSet = "dl", HowToConsume = "You need to uncork this bottle before drinking it." };
            Drinks Sprite = new Drinks { ProductName = "Sprite", ProductPrice = 16, ProductInfo = "Sprite from the Coka-Cola Company.\t", ProductId = 5, Temperature = 5, Volume = 2, VolumeSet = "dl", HowToConsume = "You need to uncork this bottle before drinking it." };
            Snacks Japp = new Snacks { ProductName = "Japp", ProductPrice = 7, ProductInfo = "Chocklate covered peanuts.\t\t", ProductId = 6, Weight = 200, WeightSet = "grams", HowToConsume = "You need to unwrap this chokolate bar before eating it." };
            Snacks Daim = new Snacks { ProductName = "Daim", ProductPrice = 8, ProductInfo = "Chocklate covered caramell.\t\t", ProductId = 7, Weight = 150, WeightSet = "grams", HowToConsume = "You need to unwrap this chokolate bar before eating it." };

            List<Products> allProducts = new List<Products>
            {
                Banana,
                Apple,
                Coffee,
                CokaCola,
                Sprite,
                Japp,
                Daim
            };

            BuyingBasket MyBasket = new BuyingBasket();

            string chosenProduct = "";
            // bool productThatExists = true;
            bool exitVendingMachine = false;
            int numberOfItemsToAdd = 0;
            int valueOfBasket = 0;
            int totalAmountOfMoney = 0;
            int change = 0;
            int menuChoise = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Vending Machines Inc! Have a drink and snack and be refreshed!");
                Console.WriteLine($"You have {totalAmountOfMoney} SEK to buy for.");
                Console.WriteLine($"You have items for a value of {valueOfBasket} SEK in your basket");
                Console.WriteLine("1. Insert money.");
                Console.WriteLine("2. List the available products.");
                Console.WriteLine("3. Examine a product.");
                Console.WriteLine("4. Show my basket.");
                Console.WriteLine("5. Add a product to basket.");
                Console.WriteLine("6. Make a purchase.");
                Console.WriteLine("7. Exit the vending machine.");
                Console.Write($"Your choise is: ");
                menuChoise = 0;
                try
                {
                    menuChoise = (Convert.ToInt32(Console.ReadLine()));
                }
                catch (FormatException)
                {
                    Console.WriteLine("You typed a letter instead of a number. Try again.");
                }

                switch (menuChoise)
                {
                    case 1: //lets the user add money to the vending machine
                        totalAmountOfMoney = totalAmountOfMoney + AddMoney(totalAmountOfMoney);
                        break;
                    case 2: //lists the current items that can be bought.
                        Console.Clear();
                        Console.WriteLine("The following products is available in this vending machine.\nName\t\t\tDescription\t\t\t\tPrice");
                        Products.Examine(allProducts);

                        Console.ReadKey();
                        break;
                    case 3: //shows more detailed info about a product 
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("What product of the following would you like to take a closer look at? \nPlease type the name of the product.");
                            Products.Examine(allProducts);
                            Console.Write("What item would you like to look closer at: ");
                            try
                            {
                                chosenProduct = Console.ReadLine();
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("You have not typed in a correct name or amount. Please try again.");
                            }
                        } while (chosenProduct == "");
                        chosenProduct = ValidateChosenProduct(chosenProduct);
                        foreach (var element in allProducts)
                        {
                            if ((chosenProduct == element.ProductName) && (element is Drinks))
                            {
                                element.ShowProductSpecifics(chosenProduct, allProducts);
                            }
                            else if ((chosenProduct == element.ProductName) && (element is Fruits))
                            {
                                element.ShowProductSpecifics(chosenProduct, allProducts);
                            }
                            else if ((chosenProduct == element.ProductName) && (element is Snacks))
                            {
                                element.ShowProductSpecifics(chosenProduct, allProducts);
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 4://shows the contents of the basket
                        valueOfBasket = MyBasket.ShowBasket(MyBasket.MyBasketContents);
                        break;
                    case 5: //lets the user add items to the basket.
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("What product would you like to add to your buying basket? \nPlease type the name of the product.");
                            Products.Examine(allProducts);
                            Console.Write("What item would you like to add: ");
                            try
                            {
                                chosenProduct = Console.ReadLine();
                                Console.Write($"How many {chosenProduct} would you like to have? ");
                                numberOfItemsToAdd = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("You have not typed in a correct name or amount. Please try again.");
                            }
                        } while (chosenProduct == "");
                        chosenProduct = ValidateChosenProduct(chosenProduct);
                        MyBasket.MyBasketContents.Add(MyBasket.AddProductToBasket(chosenProduct, numberOfItemsToAdd, allProducts, MyBasket.MyBasketContents));
                        valueOfBasket = MyBasket.BasketValue(MyBasket.MyBasketContents);
                        break;
                    case 6: //let the user get the items so far chosen and subtracts the value of the items from the inserted money.
                        if (totalAmountOfMoney <= valueOfBasket)
                        {
                            Console.WriteLine("You have not inserted enough money!!");
                            Console.ReadKey();
                            break;
                        }
                        change = totalAmountOfMoney - valueOfBasket;
                        totalAmountOfMoney = 0;
                        valueOfBasket = 0;
                        Console.ReadKey();
                        MyBasket.Purchase(change);
                        Products.Use(MyBasket.MyBasketContents, allProducts);
                        MyBasket.MyBasketContents.Clear();
                        break;
                    case 7: //exits the vending machine.
                        exitVendingMachine = true;
                        break;
                    default:
                        Console.WriteLine("You typed in a choise the vending machine dont suppport, please make another choise.");
                        Console.ReadKey();
                        break;
                }
            } while (exitVendingMachine == false);
        }
        /// <summary>
        /// This function lets a user insert coins or notes to add to their pool of money. 
        /// </summary>
        /// <param name="moneyRecivedSoFar is the amount of money the user already have."></param>
        /// <returns></returns>
        static int AddMoney(int moneyRecivedSoFar)
        {
            int recivedMoney = 0;
            int[] recievedMoneyFromUser = new int[8];
            int totalAmountOfMoney = 0;
            do
            {
                Console.WriteLine($"What currency would you like to add (1,5,10,20,50,100,500,1000): ");
                recivedMoney = 0;
                try
                {
                    recivedMoney = (Convert.ToInt32(Console.ReadLine()));
                }
                catch (FormatException)
                {
                    Console.WriteLine("You typed a letter instead of a number, please try again.");
                }
                if ((recivedMoney != 1) && (recivedMoney != 5) && (recivedMoney != 10) && (recivedMoney != 20) && (recivedMoney != 50) && (recivedMoney != 100) && (recivedMoney != 500) && (recivedMoney != 1000))
                {
                    Console.WriteLine("That is not an actual coin or note. Please try again.");
                }
            } while ((recivedMoney != 1) && (recivedMoney != 5) && (recivedMoney != 10) && (recivedMoney != 20) && (recivedMoney != 50) && (recivedMoney != 100) && (recivedMoney != 500) && (recivedMoney != 1000));
            switch (recivedMoney)
            {
                case 1:
                    recievedMoneyFromUser[0] = recievedMoneyFromUser[0] + 1;
                    break;
                case 5:
                    recievedMoneyFromUser[1] = recievedMoneyFromUser[1] + 5;
                    break;
                case 10:
                    recievedMoneyFromUser[2] = recievedMoneyFromUser[2] + 10;
                    break;
                case 20:
                    recievedMoneyFromUser[3] = recievedMoneyFromUser[3] + 20;
                    break;
                case 50:
                    recievedMoneyFromUser[4] = recievedMoneyFromUser[4] + 50;
                    break;
                case 100:
                    recievedMoneyFromUser[5] = recievedMoneyFromUser[5] + 100;
                    break;
                case 500:
                    recievedMoneyFromUser[6] = recievedMoneyFromUser[6] + 500;
                    break;
                case 1000:
                    recievedMoneyFromUser[7] = recievedMoneyFromUser[7] + 1000;
                    break;
                default:
                    break;
            }
            totalAmountOfMoney = 0;
            for (int i = 0; i <= 7; i++)
            {
                totalAmountOfMoney = totalAmountOfMoney + recievedMoneyFromUser[i];
            }
            Console.WriteLine($"You inserted {recivedMoney} SEK and have now a total of {totalAmountOfMoney + moneyRecivedSoFar} SEK");
            Console.ReadKey();
            return totalAmountOfMoney;
        }


        /// <summary>
        /// This function removes spaces before and after and makes first letter uppercase.
        /// </summary>
        /// <param name="name is the string to be validated"></param>
        /// <returns></returns>
        static string ValidateChosenProduct(string name)
        {
            name = name.Trim();
            string firstOldLetter = Convert.ToString(name[0]);
            string firstLetter = firstOldLetter.ToUpper();
            for (int i = 1; i < (name.Length); i++)
            {
                firstLetter = firstLetter + name[i];
            }
            name = firstLetter;
            return name;
        }
    }
}
