namespace ExercisingPlanAPI.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TargetMuscleGroupId { get; set; }
        public TargetMuscleGroup TargetMuscleGroup { get; set; }
    }
}
