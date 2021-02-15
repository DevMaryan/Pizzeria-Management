using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Repositories
{
    public class PizzaRepository
    {
        public PizzaRepository()
        {
            Pizza_DB = new List<Pizza>();
            Completed_Orders = new List<Pizza>();
        }

        public List<Pizza> Pizza_DB { get; set; }
        public List<Pizza> Completed_Orders { get; set; }

        public void Create(Pizza newPizza)
        {
            Pizza_DB.Add(newPizza);
        }

        public void Delete(Pizza selectedPizza)
        {
            Pizza_DB.Remove(selectedPizza);
        }

        public void Completed(Pizza marked)
        {
            Completed_Orders.Add(marked);
            Pizza_DB.Remove(marked);
        }
    }


}
