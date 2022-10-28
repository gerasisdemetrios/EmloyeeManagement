using EM.App.Repository;
using EM.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace EM.App.Pages.Skills
{
    public partial class UpdateSkill : ComponentBase
    {
        [Parameter]
        public int skillId { get; set; }
        protected string Title = "Update";

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
            if (skill.Id != 0)
            {
                await Repo.UpdateSkill(skillId, skill);
            }
           
            Cancel();
        }


        public void Cancel()
        {
            NavigationManager.NavigateTo("/skills");
        }
    }
}
