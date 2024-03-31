namespace ExercisingPlanAPI.Models
{
    public class ExercisingPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DynamicTable Plan { get; set; } = null!;
        public int OwnerId { get; set; }
        public User Owner { get; set; } = null!;
    }
}
