namespace ExercisingPlanAPI.DTOs
{
    public class ExerciseFullDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TargetMuscleGroupDto TargetMuscleGroup { get; set; }
    }
}
