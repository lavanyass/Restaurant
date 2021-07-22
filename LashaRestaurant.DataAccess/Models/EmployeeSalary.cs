using System;
using System.Collections.Generic;

namespace LashaRestaurant.DataAccess.Models
{
    public partial class EmployeeSalary
    {
        public int EmployeeSalaryId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime SalaryDate { get; set; }
        public decimal SalaryAmt { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
