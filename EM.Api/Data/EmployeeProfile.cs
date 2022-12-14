using AutoMapper;
using EM.Api.Models;
using EM.Shared.DTOs;

namespace EM.Api.Data
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {

            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Skills, src => src.MapFrom(x => x.EmployeeSkills))
                .ForMember(dest => dest.Department, src => src.MapFrom(x => x.Dapartment.Name));

            CreateMap<EmployeeDto, Employee>()
                .ForMember(dest => dest.EmployeeSkills, src => src.MapFrom(x => x.Skills));


            CreateMap<EmployeeSkill, SkillDto>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Skill.Id))
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.SkillId))
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Skill.Name))
                .ForMember(dest => dest.CreatedAt, src => src.MapFrom(x => x.Skill.CreatedAt))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Skill.Description))
                .ReverseMap();

            CreateMap<EmployeeSkill, EmployeeDto>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.EmployeeId))
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Employee.Id))
                .ReverseMap();

        }
    }
}
