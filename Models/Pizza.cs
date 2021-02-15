using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public EnumSize Size { get; set; }
        public List<string> Toppings { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Driver Driver { get; set; }
        public DateTime Date { get; set; }
        public Pizza(int id, string type, EnumSize size, List<string> toppings, string address, string phone, Driver driver, DateTime date)
        {
            Id = id;
            Type = type;
            Size = size;
            Toppings = toppings;
            Address = address;
            Phone = phone;
            Driver = driver;
            Date = date;
        }

        public Pizza()
        {
        }
    }
}
