namespace ExercisingPlanAPI.Models
{
    public class WeekPlan
    {
        public int WeekNumber { get; set; }
        public int WeekdayId { get; set; }
        public Weekday Weekday { get; set; }
        public int ExercisingPlanId { get; set; }
        public ExercisingPlan ExercisingPlan { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
