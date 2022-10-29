using EM.App.Repository;
using EM.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.App.Pages.Employees
{
    public partial class Employee : ComponentBase
    {
        public List<EmployeeDto> EmployeesList { get; set; } = new List<EmployeeDto>();

        [Inject]
        public IEmployeeRepository Repo { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            EmployeesList = await Repo.GetEmployees();
        }

        private async Task DeleteEmployee(int id)
        {
            await Repo.DeleteEmployee(id);

            await OnInitializedAsync();
        }

        private void UpdateEmployee(int id)
        {
            NavigationManager.NavigateTo($"/employee/update/{id}");
        }
    }
}
