using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using Repositories;

namespace Services
{
    public class Service
    {

        // Set repositories

        public Service()
        {
            _Pizza = new Pizza();
            _Driver = new Driver();
            _driverRepository = new DriverRepository();
            _pizzaRepository = new PizzaRepository();
            _employeeRepository = new EmployeeRepository();
        }
        
        public Pizza _Pizza { get; set; }
        public Driver _Driver { get; set; }
        public DriverRepository _driverRepository { get; set; }
        public PizzaRepository _pizzaRepository { get; set; }
        public EmployeeRepository _employeeRepository { get; set; }

        // CREATE DRIVERS //
        public void CreateDriver()
        {
            // Driver Info
            Console.WriteLine("Please enter driver name");
            var driverName = Console.ReadLine();

            Console.WriteLine("Please enter driver surname");
            var driverSurname = Console.ReadLine();

            List<string> status = new List<string>() { "Available", "Out on delivery" };
            Console.WriteLine("Please enter driver status");
            for(var i = 0; i < status.Count; i++)
            {
                Console.WriteLine($"{i} {status[i]}");
            }
            var theChoice = int.Parse(Console.ReadLine());
            if (theChoice == 0)
            {

                var driverStatus = "Available";
                DateTime localDate = DateTime.Now;
                Driver newDriver = new Driver(GenerateDriverIds(), driverName, driverSurname, driverStatus, localDate);
                if (newDriver != null)
                {
                    try
                    {
                        _driverRepository.Create(newDriver);
                        Console.WriteLine($"{newDriver.Name} is added. ");
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Driver couldn't be created!");
                    }
                }
            }else if(theChoice == 1)
            {

                var driverStatus = "Not Available";
                DateTime localDate = DateTime.Now;
                Driver newDriver = new Driver(GenerateDriverIds(), driverName, driverSurname, driverStatus, localDate);
                if (newDriver != null)
                {
                    try
                    {
                        _driverRepository.Create(newDriver);
                        Console.WriteLine($"{newDriver.Name} is added. ");
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Driver couldn't be created!");
                    }
                }
            }
        }

        public void ActiveOrders()
        {
            if(_pizzaRepository.Pizza_DB != null)
            {
                Console.WriteLine("Those orders are not delivered");
                foreach (var order in _pizzaRepository.Pizza_DB)
                {
                    Console.WriteLine($"{order.Id} {order.Address}");
                }
            }
            else if(_pizzaRepository.Pizza_DB == null)
            {
                Console.WriteLine("NO ACTIVE ORDERS");
            }
            else
            {
                Console.WriteLine("No clue");
            }

        }
        public void DeliveredOrders()
        {
            if(_pizzaRepository.Completed_Orders != null)
            {
                Console.WriteLine("Those orders are delivered");
                Console.WriteLine("");
                foreach (var order in _pizzaRepository.Completed_Orders)
                {
                    Console.WriteLine($"{order.Id} delviered by {order.Driver.Name}");
                }
            }
            else
            {
                Console.WriteLine("ALL ORDERS ARE DELIVERED!");
            }
        }

        public void DeleteDriver()
        {
            Console.WriteLine("You choose to DELETE DRIVER");
            // List All Drivers
            AllDrivers();

            // Choose user which one to delete
            Console.WriteLine("Please select driver by ID.");
            var userChoice = int.Parse(Console.ReadLine());

            // Select the user from Driver DB
            var selectedDriver = _driverRepository.Driver_DB.FirstOrDefault(x => x.Id == userChoice);


            if(_driverRepository.Driver_DB != null)
            {
                _driverRepository.Delete(selectedDriver);
                Console.WriteLine($"Driver {selectedDriver.Name} has been deleted.");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("No Drivers");
            }

        }
        public void AllDrivers()
        {
            if(_driverRepository.Driver_DB != null)
            {
                foreach(var driver in _driverRepository.Driver_DB)
                {
                    Console.WriteLine($"ID {driver.Id}, {driver.Name}, {driver.Surname}, Status {driver.Status} | Hired at: {driver.Date}");
                }
            }
        }

        public int GenerateDriverIds()
        {
            var newId = 0;
            if(_driverRepository.Driver_DB.Count > 0)
            {
                newId = _driverRepository.Driver_DB.Max(x => x.Id);
            }
            return newId + 1;
        }



        // CREATE ORDERS /
        public void CreateOrder()
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
            var pickType = Console.ReadLine();
            var chosenType = "";
            if (pickType == "0")
            {
                chosenType = "deepdish";
            }
            else if (pickType == "1")
            {
                chosenType = "pan";
            }
            else if (pickType == "2")
            {
                chosenType = "thin curst";
            }
            else
            {
                Console.WriteLine("Invalid Style!");
            }



            // Choose Size
            Console.WriteLine("Please choose size");
            var sizes = Enum.GetValues(typeof(EnumSize));

            foreach(var size in sizes)
            {
                var valueze = (int)size;
                Console.WriteLine($"{(int)size} - {size}");
            }
            var chosenSize = int.Parse(Console.ReadLine());

            // Toppings
            List<string> toppings = new List<string>() { "pepperoni", "sausage", "bacon" };
            Console.WriteLine("Please choose toppings: ");

            foreach(var top in toppings)
            {
                Console.WriteLine(top);
            }

            List<string> chosenToppings = new List<string>();

            var addTopping = Console.ReadLine();
            chosenToppings.Add(addTopping);
            Console.WriteLine($"{addTopping} is added.");
            Console.WriteLine("Choose the second topping");
            var secondTopping = Console.ReadLine();
            chosenToppings.Add(secondTopping);
            Console.WriteLine($"{secondTopping} is added.");
            // Pick Driver
            Console.WriteLine("The following drivers are available");

            // List all drivers
            if(_driverRepository.Driver_DB != null)
            {
                foreach (var driver in _driverRepository.Driver_DB)
                {
                    Console.WriteLine($"{driver.Id} {driver.Name}");
                }
            }
            else
            {
                Console.WriteLine("No drivers avialable");
            }
            Console.WriteLine("Please choose driver ID ");

            var driverId = int.Parse(Console.ReadLine());


            // Chosen Driver
            var chosenDriver = _driverRepository.Driver_DB.FirstOrDefault(x => x.Id == driverId);

            DateTime localDate = DateTime.Now;

            var newPizza = new Pizza();
            newPizza.Id = GeneratePizzaIds();
            newPizza.Type = chosenType;
            newPizza.Size = (EnumSize)chosenSize;
            newPizza.Toppings = chosenToppings;
            newPizza.Address = customerAddress;
            newPizza.Phone = customerPhone;
            newPizza.Driver = chosenDriver;
            newPizza.Date = localDate;

            if (chosenDriver != null)
            {
                chosenDriver.Status = "On delivery";
                _driverRepository.OnDelivery(chosenDriver);
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("No driver available");
                Console.WriteLine("");
            }


            if (_pizzaRepository.Pizza_DB != null)
            {
                try
                {
                    _pizzaRepository.Create(newPizza);
                    Console.WriteLine($"New order is created");
                    Console.WriteLine($"Order id {newPizza.Id} at {newPizza.Date}");
                }
                catch
                {
                    Console.WriteLine("Pizza not created, an error occured");
                }
                
            }
            Receipt(newPizza);
        }
        public void OnDeliveryM()
        {
            foreach(var driver in _driverRepository.OnDelivery_Driver)
            {
                Console.WriteLine($"{driver.Id} {driver.Name}");
            }
        }
        public void Receipt(Pizza newPizza)
        {
            Console.WriteLine("Thank you for choosing Sarpinos Pizzeria");
            Console.WriteLine($"You ordered {newPizza.Size} with");
            Console.WriteLine("");
            foreach(var item in newPizza.Toppings)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Your total is:");
            var total = 20 * newPizza.Toppings.Count;
            Console.WriteLine($"\t${total}");
            Console.WriteLine("");

        }
        public void MarkDelviered()
        {
            // Show all orders
            try
            {
                foreach (var order in _pizzaRepository.Pizza_DB)
                {
                    Console.WriteLine($"{order.Id}, {order.Address}");
                }
                Console.WriteLine("Which order is completed?");
                Console.WriteLine("Enter ID number");
                var chosenID = int.Parse(Console.ReadLine());
                var marked = _pizzaRepository.Pizza_DB.FirstOrDefault(x => x.Id == chosenID);
                try
                {
                    _pizzaRepository.Completed(marked);
                    _driverRepository.DoneDelivery(marked.Driver);
                }
                catch
                {
                    Console.WriteLine("THERE IS NO DRIVER SELECTED");
                }
                Console.WriteLine($"{marked.Id} is delivered by {marked.Driver.Name}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public int GeneratePizzaIds()
        {
            var newId = 0;
            if (_pizzaRepository.Pizza_DB.Count > 0)
            {
                newId = _pizzaRepository.Pizza_DB.Max(x => x.Id);
            }
            return newId + 1;
        }

    }
}
