using Atropos.Data.Models;

namespace Atropos.Data.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(Guid id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee, Guid id);
        Task<bool> DeleteEmployee(Guid id);
    }
}
