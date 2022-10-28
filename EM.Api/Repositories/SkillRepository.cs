using EM.Api.Models;

namespace EM.Api.Repositories
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository(EMContext context) : base(context)
        {
        }
    }
}
