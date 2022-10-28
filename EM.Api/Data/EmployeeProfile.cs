using AutoMapper;
using EM.Api.Models;
using EM.Shared.DTOs;

namespace EM.Api.Data
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {

            CreateMap<Employee, EmployeeDto>().ForMember(dest => dest.Skills, src => src.MapFrom(x => x.EmployeeSkills)).ReverseMap();
            
            CreateMap<EmployeeSkill, SkillDto>().ForMember(dest => dest.Id, src => src.MapFrom(x => x.Skill.Id)).ForMember(dest => dest.Id, src => src.MapFrom(x => x.SkillId)).ForMember(dest => dest.Name, src => src.MapFrom(x => x.Skill.Name)).ReverseMap();

            CreateMap<EmployeeSkill, EmployeeDto>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.EmployeeId))
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Employee.Id)).ReverseMap();

        }
    }
}
