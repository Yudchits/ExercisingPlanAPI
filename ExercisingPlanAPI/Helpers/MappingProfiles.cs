using AutoMapper;
using ExercisingPlanAPI.Models;
using ExercisingPlanAPI.DTOs;

namespace ExercisingPlanAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
            CreateMap<ExercisingPlan, ExercisingPlanDto>();
            CreateMap<ExercisingPlanDto, ExercisingPlan>();
        }
    }
}
