using EM.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.App.Repository
{
    public interface IDepartmentRepository
    {
        Task<List<DepartmentDto>> GetDepartments();
        Task<DepartmentDto> GetDepartment(int id);
        Task<DepartmentDto> UpdateDepartment(int id, DepartmentDto departmentDto);
        Task<DepartmentDto> CreateDepartment(DepartmentDto departmentDto);
        Task DeleteDepartment(int id);
    }
}
