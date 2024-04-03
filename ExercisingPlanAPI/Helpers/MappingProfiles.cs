using AutoMapper;
using ExercisingPlanAPI.Models;
using ExercisingPlanAPI.DTOs;

namespace ExercisingPlanAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ExercisingPlan, ExercisingPlanDto>();
            CreateMap<ExercisingPlanDto, ExercisingPlan>();
        }
    }
}
