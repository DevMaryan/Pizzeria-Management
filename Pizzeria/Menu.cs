using System;
using System.Collections.Generic;
using System.Text;
using Services;

namespace Pizzeria
{
    public class Menu
    {

        public static Service Service { get; set; }
        public static void MenuHelper()
        {
            Service = new Service();
 
            Console.WriteLine("Welcome to Sarpinos Pizzeria");
            Console.WriteLine("Please choose one of the following options");
            MainMenu();
        }
        public static void MainMenu()
        {
            bool mustStop = false;

            while(mustStop != true)
            {
                Console.WriteLine("1. Create Order");
                Console.WriteLine("2. Mark orderas complete");
                Console.WriteLine("3. Manage Pizza");
                Console.WriteLine("4. Manage Delivery drivers");
                Console.WriteLine("5. Active orders");
                Console.WriteLine("6. Delivered orders");
                Console.WriteLine("7. Out on Delviery");
                var userChoice = Console.ReadLine();

                try
                {
                    switch (userChoice)
                    {
                        case "1":
                            Console.WriteLine("You choose to Create Order");
                            Service.CreateOrder();
                            break;
                        case "2":
                            Console.WriteLine("You choose to Mark Orders");
                            Service.MarkDelviered();
                            break;
                        case "3":
                            Console.WriteLine("You choose to Manage Pizza");

                            break;
                        case "4":
                            Console.WriteLine("You choose to Manage Delivery drivers");
                            ManageDeliveryDrivers();
                            break;
                        case "5":
                            Console.WriteLine("Active orders");
                            Service.ActiveOrders();
                            break;
                        case "6":
                            Console.WriteLine("Delivered Orders");
                            Service.DeliveredOrders();
                            break;
                        case "7":
                            Console.WriteLine("Drivers out of delivery");
                            Service.OnDeliveryM();
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                    Console.WriteLine("Would you like to exit? Enter E to exit");
                    var userMustStop = Console.ReadLine();
                    if(userMustStop == "E")
                    {
                        mustStop = true;
                    }
                }
                catch (Exception e)
                {
                    var date = new DateTime();
                    Console.WriteLine(date.ToString(), e.Message);

                }
            }
        }
        public static void ManageDeliveryDrivers()
        {
            Console.WriteLine("");

            Console.WriteLine("1. To add new delivery driver");
            Console.WriteLine("2. To delete delivery driver");
            Console.WriteLine("3. View All Drivers");
            var userChoice = int.Parse(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("You choose to add delivery driver");
                    Service.CreateDriver();
                    break;
                case 2:
                    Console.WriteLine("You choose to delete delivery driver");
                    Service.DeleteDriver();
                    break;
                case 3:
                    Service.AllDrivers();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

        }
     }
}
