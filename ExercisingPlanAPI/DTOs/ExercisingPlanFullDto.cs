using System.Collections.Generic;

namespace ExercisingPlanAPI.DTOs
{
    public class ExercisingPlanFullDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserDto Owner { get; set; } = null!;
        public ICollection<WeekPlanEntityDto> WeekPlans { get; set; }
    }
}
