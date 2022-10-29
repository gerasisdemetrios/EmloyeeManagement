using EM.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.App.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeDto>> GetEmployees();
        Task<EmployeeDto> GetEmployee(int id);
        Task<EmployeeDto> UpdateEmployee(int id, EmployeeDto skillDto);
        Task<EmployeeDto> CreateEmployee(EmployeeDto skillDto);
        Task DeleteEmployee(int id);
    }
}
