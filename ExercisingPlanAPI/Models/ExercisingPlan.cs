using System.Collections.Generic;

namespace ExercisingPlanAPI.Models
{
    public class ExercisingPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public ICollection<WeekPlan> WeekPlans { get; set; }
    }
}
