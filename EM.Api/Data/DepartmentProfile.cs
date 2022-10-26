using AutoMapper;
using EM.Api.Models;
using EM.Shared.DTOs;

namespace EM.Api.Data
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>()
                .ReverseMap();
        }
    }
}
