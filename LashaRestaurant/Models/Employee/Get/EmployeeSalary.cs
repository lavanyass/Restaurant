﻿using System;

namespace LashaRestaurant.Models.Employee.Get
{
    public partial class EmployeeSalary
    {
        public int EmployeeSalaryId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime SalaryDate { get; set; }
        public decimal SalaryAmt { get; set; }
    }
}
