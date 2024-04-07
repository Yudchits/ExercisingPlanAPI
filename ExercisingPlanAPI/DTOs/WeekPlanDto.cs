using ExercisingPlanAPI.Models;

namespace ExercisingPlanAPI.DTOs
{
    public class WeekPlanDto
    {
        public WeekNumber WeekNumber { get; set; }
        public Weekday Weekday { get; set; }
        public ExerciseFullDto Exercise { get; set; }
    }
}
