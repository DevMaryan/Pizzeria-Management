using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace Repositories
{
    public class EmployeeRepository
    {
        public EmployeeRepository()
        {
            Employee_DB = new List<Employee>();
        }

        public List<Employee> Employee_DB { get; set; }
    }
}
