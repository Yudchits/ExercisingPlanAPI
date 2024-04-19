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

            CreateMap<TargetMuscleGroup, TargetMuscleGroupDto>();
            CreateMap<TargetMuscleGroupDto, TargetMuscleGroup>();

            CreateMap<WeekPlan, WeekPlanIdDto>();
            CreateMap<WeekPlanIdDto, WeekPlan>();
            CreateMap<WeekPlan, WeekPlanEntityDto>();
            CreateMap<WeekPlanEntityDto, WeekPlan>();

            CreateMap<Exercise, ExerciseBriefDto>();
            CreateMap<ExerciseBriefDto, Exercise>();
            CreateMap<Exercise, ExerciseFullDto>();
            CreateMap<ExerciseFullDto, Exercise>();

            CreateMap<ExercisingPlan, ExercisingPlanBriefDto>();
            CreateMap<ExercisingPlanBriefDto, ExercisingPlan>();
            CreateMap<ExercisingPlan, ExercisingPlanFullDto>();
            CreateMap<ExercisingPlanFullDto, ExercisingPlan>();
        }
    }
}
