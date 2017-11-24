using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Models
{
    public class EmployeesViewModel
    {
        public List<Employee> Employees { get; set; }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string Profile { get; set; }
        public List<Friend> Friends { get; set; }
    }

    public class Friend
    {
        public string Name { get; set; }
    }
}
