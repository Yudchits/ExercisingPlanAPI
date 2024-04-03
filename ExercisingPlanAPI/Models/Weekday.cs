using System.Collections.Generic;

namespace ExercisingPlanAPI.Models
{
    public class Weekday
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<WeekdayExercise> WeekdayExercises { get; set; }
    }
}
