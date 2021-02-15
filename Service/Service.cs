using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class Service
    {

        public static void CreateOrder()
        {
            // Customer Phone number
            Console.WriteLine("Enter customer phone number");
            string customerPhone = Console.ReadLine();

            // Customer Delivery Address
            Console.WriteLine("Enter customer delivery address");
            string customerAddress = Console.ReadLine();

            // Chosen Type
            List<string> pizzatypes = new List<string>() { "deepdish", "pan", "thin crust" };

            Console.WriteLine("Please choose pizza type");
            for (var i = 0; i < pizzatypes.Count; i++)
            {
                Console.WriteLine($"{i} - {pizzatypes[i]}");
            }
            var chosenType = int.Parse(Console.ReadLine());


            // Choose Size
            List<string> pizzaSize = new List<string>() { "12'' Medium", "14'' Large", "16'' X-Large", "18'' Jumbo" };
            Console.WriteLine("Please choose pizza size");
            for (var i = 0; i < pizzaSize.Count; i++)
            {
                Console.WriteLine($"{i} - {pizzaSize[i]}");
            }


        }

    }
}
