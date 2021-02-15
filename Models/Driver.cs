using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Status { get; set; }

        public DateTime Date { get; set; }

        public Driver(int id, string name, string surname, string status, DateTime date)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Status = status;
            Date = date;
        }

        public Driver()
        {
        }

        public void DriverInfo()
        {
            Console.WriteLine($"{Id} - {Name} {Surname} - {Status} ");
        }
    }
}
