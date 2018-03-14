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
            bool exitVendingMachine = false;

            int recivedMoney = 0;
            int[] recievedMoneyFromUser = new int[8];
            int totalAmountOfMoney = 0;
            int menuChoise = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Vending Machines Inc! Have a drink and snack and be refreshed!");
                Console.WriteLine($"You have {totalAmountOfMoney} money to buy for.");
                Console.WriteLine("1. Examine a product.");
                Console.WriteLine("2. Add a product to basket.");
                Console.WriteLine("3. Add more money.");
                Console.WriteLine("4. Make a purchase");
                Console.WriteLine("5. Exit the vending machine.");
                menuChoise = (Convert.ToInt32(Console.ReadLine()));
                //try
                //{
                //    menuChoise = (Convert.ToInt32(Console.ReadLine()));
                //}
                //catch (FormatException)
                //{
                //    Console.WriteLine("You typed a letter instead of a number. Try again");
                //}

                switch (menuChoise)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        {
                            do
                            {
                                Console.WriteLine($"What currency would you like to add (1,5,10,20,50,100,500,1000): ");
                                try
                                {
                                    recivedMoney = (Convert.ToInt32(Console.ReadLine()));
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("You typed a letter instead of a number, please try again.");
                                }
                                if ((recivedMoney != 1) || (recivedMoney != 5))// || (recivedMoney != 10) || (recivedMoney != 20) || (recivedMoney != 50) || (recivedMoney != 100) || (recivedMoney != 500) || (recivedMoney != 1000))
                                {
                                    Console.WriteLine("That is not an actual coin or note. Please try again.");
                                }
                            } while ((recivedMoney != 1) || (recivedMoney != 5)); // || recivedMoney != 10 || recivedMoney != 20 || recivedMoney != 50 || recivedMoney != 100 || recivedMoney != 500 || recivedMoney != 1000);
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
                            for (int i = 0; i <= 7; i++)
                            {
                                totalAmountOfMoney = totalAmountOfMoney + recievedMoneyFromUser[i];
                            }
                            Console.WriteLine($"You inserted {recivedMoney} and have now a total of {totalAmountOfMoney}");
                            break;
                        }
                    case 4:
                        break;
                    case 5:
                        exitVendingMachine = true;
                        break;
                    default:
                        break;
                }
                
            }while (exitVendingMachine == false) ;
        }
    }
}
