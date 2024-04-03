namespace ExercisingPlanAPI.Models
{
    public class WeekdayExercise
    {
        public int WeekdayId { get; set; }
        public Weekday Weekday { get; set; } = null!;
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; } = null!;
    }
}
