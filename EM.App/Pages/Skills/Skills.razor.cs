using EM.App.Repository;
using EM.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EM.App.Pages.Skills
{
    public partial class Skills : ComponentBase
    {
        public List<SkillDto> SkillsList { get; set; } = new List<SkillDto>();

        [Inject]
        public ISkillRepository Repo { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            SkillsList = await Repo.GetSkills();
        }

        private async Task DeleteSkill(int id)
        {
            await Repo.DeleteSkill(id);

            await OnInitializedAsync();
        }

        private async Task UpdateSkill(int id)
        {
            NavigationManager.NavigateTo($"/skill/update/{id}");
        }
    }
}
