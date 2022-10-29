using EM.App.Repository;
using EM.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EM.App.Pages.EmployeeSkills
{
    public partial class EmployeeSkills : ComponentBase
    {
        [Parameter]
        public int employeeId { get; set; }
        protected EmployeeDto employee = new();
        public List<SkillDto> SkillsList { get; set; } = new List<SkillDto>();

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        public IEmployeeRepository EmployeeRepo { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (employeeId != 0)
            {
                employee = await EmployeeRepo.GetEmployee(employeeId);

                SkillsList = employee.Skills;
            }
        }

        private async Task DeleteSkill(int id)
        {
            employee.Skills.Remove(SkillsList.Where(x => x.Id == id).SingleOrDefault());

            await EmployeeRepo.UpdateEmployee(employee.Id, employee);

            await OnInitializedAsync();
        }

        private void Back()
        {
            NavigationManager.NavigateTo($"/employees");
        }
    }
}
