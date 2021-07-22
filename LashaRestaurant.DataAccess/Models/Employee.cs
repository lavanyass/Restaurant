using System;
using System.Collections.Generic;

namespace LashaRestaurant.DataAccess.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeBankAccount = new HashSet<EmployeeBankAccount>();
            EmployeeSalary = new HashSet<EmployeeSalary>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<EmployeeBankAccount> EmployeeBankAccount { get; set; }
        public virtual ICollection<EmployeeSalary> EmployeeSalary { get; set; }
    }
}
