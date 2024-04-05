namespace ExercisingPlanAPI.Models
{
    public class UserExercisingPlan
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int ExercisingPlanId { get; set; }
        public ExercisingPlan ExercisingPlan { get; set; } = null!;
    }
}
