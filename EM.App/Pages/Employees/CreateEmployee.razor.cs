using EM.App.Repository;
using EM.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EM.App.Pages.Employees
{
    public partial class CreateEmployee: ComponentBase
    {
        [Parameter]
        public int employeeId { get; set; }
        protected string Title = "Create";

        protected EmployeeDto employee = new();

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        public IEmployeeRepository EmployeeRepo { get; set; }
        [Inject]
        public IDepartmentRepository DepartmentRepo { get; set; }
        public List<DepartmentDto> DepartmentsList { get; private set; } = new();

        protected async override Task OnInitializedAsync()
        {
            DepartmentsList = await DepartmentRepo.GetDepartments();

            employee.DepartmentId = DepartmentsList.FirstOrDefault()?.Id;
        }

        protected async Task Save()
        {
            if (!string.IsNullOrWhiteSpace(employee.FirstName) && !string.IsNullOrWhiteSpace(employee.LastName))
            {
                await EmployeeRepo.CreateEmployee(employee);
            }

            Cancel();
        }

        public void Cancel()
        {
            NavigationManager.NavigateTo("/employees");
        }

    }
}
