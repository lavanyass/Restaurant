using System;
using System.ComponentModel.DataAnnotations;

namespace LashaRestaurant.Models.Employee.Put
{
    public class EmployeePut
    {
        [Required]
        public int? EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmployeeFirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmployeeLastName { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [MaxLength(1)]
        public string Gender { get; set; }

    }
}
