using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LashaRestaurant.Models.Employee.Post
{
    public class EmployeePost
    {

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
