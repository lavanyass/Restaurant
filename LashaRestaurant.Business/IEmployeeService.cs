using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LashaRestaurant.DataAccess.Models;

namespace LashaRestaurant.Business
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int employeeId);
        Task<Employee> Create(Employee employee);
        Task<Employee> Update(Employee employee);
    }
}
