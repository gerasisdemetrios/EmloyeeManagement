using AutoMapper;
using EM.Api.Models;
using EM.Shared.DTOs;

namespace EM.Api.Data
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<Skill, SkillDto>()
                .ReverseMap();
        }
    }
}
