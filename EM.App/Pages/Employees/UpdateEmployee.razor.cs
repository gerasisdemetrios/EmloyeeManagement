using EM.App.Repository;
using EM.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.App.Pages.Employees
{
    public partial class UpdateEmployee : ComponentBase
    {
        [Parameter]
        public int employeeId { get; set; }
        protected string Title = "Update";

        protected EmployeeDto employee = new();

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        public IEmployeeRepository EmployeeRepo { get; set; }
        [Inject]
        public IDepartmentRepository DepartmentRepo { get; set; }
        public List<DepartmentDto> DepartmentsList { get; private set; }

        protected async override Task OnInitializedAsync()
        {
            DepartmentsList = await DepartmentRepo.GetDepartments();
        }
        protected override async Task OnParametersSetAsync()
        {
            if (employeeId != 0)
            {
                employee = await EmployeeRepo.GetEmployee(employeeId);
            }
        }

        protected async Task Save()
        {
            if (employee.Id != 0)
            {
                await EmployeeRepo.UpdateEmployee(employeeId, employee);
            }

            Cancel();
        }


        public void Cancel()
        {
            NavigationManager.NavigateTo("/employees");
        }

    }
}
