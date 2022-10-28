using EM.App.Repository;
using EM.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace EM.App.Pages.Skills
{
    public partial class CreateSkill : ComponentBase
    {
        [Parameter]
        public int skillId { get; set; }
        protected string Title = "Create";

        protected SkillDto skill = new();

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        public IHttpRepository Repo { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (skillId != 0)
            {
                skill = await Repo.GetSkill(skillId);
            }
        }

        protected async Task Save()
        {
            if (!string.IsNullOrWhiteSpace(skill.Name) )
            {
                await Repo.CreateSkill( skill);
            }

            Cancel();
        }


        public void Cancel()
        {
            NavigationManager.NavigateTo("/skills");
        }
    }
}
