using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date { get; set; }

        public Employee(int id, string name, string surname, DateTime date)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Date = date;
        }

        public void DriverInfo()
        {
            Console.WriteLine($"{Id} - {Name} {Surname}");
        }
    }
}
