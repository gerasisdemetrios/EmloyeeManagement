using EM.App.Repository;
using EM.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EM.App.Pages.EmployeeSkills
{
    public partial class CreateEmployeeSkill : ComponentBase
    {
        [Parameter]
        public int employeeId { get; set; }
        public int skillId { get; set; }

        protected EmployeeDto employee = new();

        protected SkillDto skill = new();
        public List<SkillDto> SkillsList { get; set; } = new List<SkillDto>();

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        public IEmployeeRepository EmployeeRepo { get; set; }

        [Inject]
        public ISkillRepository SkillRepo { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (employeeId != 0)
            {
                employee = await EmployeeRepo.GetEmployee(employeeId);

                SkillsList = await SkillRepo.GetSkills();

                foreach (var s in employee.Skills)
                {
                    var todelete = SkillsList.Where(x => x.Id == s.Id).Single();
                    SkillsList.Remove(todelete);
                }

                if (SkillsList != null && SkillsList.Count > 0)
                {
                    skillId = SkillsList.First().Id;
                    skill = SkillsList.First();
                }
            }
        }

        protected async Task Save()
        {
            if (employee != null)
            {
                if (SkillsList.Count > 0)
                {
                    employee.Skills.Add(SkillsList.Where(x => x.Id == skillId).Single());
                    await EmployeeRepo.UpdateEmployee(employee.Id, employee);
                }
            }

            Cancel();
        }

        public void Cancel()
        {
            NavigationManager.NavigateTo($"/employees/{employee.Id}/skills");
        }
    }
}
