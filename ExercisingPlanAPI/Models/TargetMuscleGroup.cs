using System.Collections.Generic;

namespace ExercisingPlanAPI.Models
{
    public class TargetMuscleGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}