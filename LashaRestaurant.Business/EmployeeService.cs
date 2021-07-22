using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LashaRestaurant.DataAccess;
using LashaRestaurant.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace LashaRestaurant.Business
{
    public class EmployeeService : IEmployeeService
    {
        private readonly LashaRestaurantDbContext _context;

        public EmployeeService(LashaRestaurantDbContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> GetAll()
        {
            return await _context
                .Employee
                .AsNoTracking()
                .Include(e=>e.EmployeeBankAccount)
                .Include(e => e.EmployeeSalary)
                .ToListAsync();
        }

        public async Task<Employee> GetById(int employeeId)
        {
            return await _context.Employee.AsNoTracking().FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<Employee> Create(Employee employee)
        { 
            await _context.Employee.AddAsync(employee);

            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> Update(Employee employee)
        {
            var dbEmployee = await _context.Employee.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if (dbEmployee == null)
            {
                return null;
            }

            dbEmployee.EmployeeFirstName = employee.EmployeeFirstName;
            dbEmployee.EmployeeLastName = employee.EmployeeLastName;
            dbEmployee.DateOfBirth = employee.DateOfBirth;
            dbEmployee.Gender = employee.Gender;

            await _context.SaveChangesAsync();


            return dbEmployee;
        }
    }
}
