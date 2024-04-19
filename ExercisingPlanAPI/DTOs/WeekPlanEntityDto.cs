using ExercisingPlanAPI.Models;

namespace ExercisingPlanAPI.DTOs
{
    public class WeekPlanEntityDto
    {
        public WeekNumber WeekNumber { get; set; }
        public Weekday Weekday { get; set; }
        public ExerciseFullDto Exercise { get; set; }
    }
}
