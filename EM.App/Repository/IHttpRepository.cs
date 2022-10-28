using EM.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.App.Repository
{
    public interface ISkillRepository
    {
        Task<List<SkillDto>> GetSkills();
        Task<SkillDto> GetSkill(int id);
        Task<SkillDto> UpdateSkill(int id, SkillDto skillDto);
        Task<SkillDto> CreateSkill(SkillDto skillDto);
        Task DeleteSkill(int id);
    }
}
