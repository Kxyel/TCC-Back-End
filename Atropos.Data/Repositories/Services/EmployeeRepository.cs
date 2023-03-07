using Atropos.Data.Data;
using Atropos.Data.Models;
using Atropos.Data.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Atropos.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> GetEmployeeById(Guid id)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();

            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();

            return employee;
        }

        public async Task<bool> DeleteEmployee(Guid id)
        {
            var employee = await GetEmployeeById(id);

            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();

            return true;
        }

        public async Task<Employee> UpdateEmployee(Employee employee, Guid id)
        {
            var employeeResult = await GetEmployeeById(id);

            if (!string.IsNullOrWhiteSpace(employee.Name))
                employeeResult.Name = employee.Name;

            if (!string.IsNullOrWhiteSpace(employee.Email))
                employeeResult.Email = employee.Email;

            if (!string.IsNullOrWhiteSpace(employee.Cpf))
                employeeResult.Cpf = employee.Cpf;

            if (employee.Age != 0)
                employeeResult.Age = employee.Age;

            if (employee.Phone != 0)
                employeeResult.Phone = employee.Phone;

            if (employee.Salary != 0)
                employeeResult.Salary = employee.Salary;

            if (!string.IsNullOrWhiteSpace(employee.Department))
                employeeResult.Department = employee.Department;

            employeeResult.IsActive = employee.IsActive;
            employeeResult.ChangeDate = DateTime.Now;
           
            _dbContext.Employees.Update(employeeResult);
            _dbContext.SaveChanges();

            return employeeResult;

        }
    }
}
