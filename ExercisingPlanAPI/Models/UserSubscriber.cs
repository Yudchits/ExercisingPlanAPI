namespace ExercisingPlanAPI.Models
{
    public class UserSubscriber
    {
        public int SubscriberId { get; set; }
        public User Subscriber { get; set; } = null!;
        public int SubscribeToId { get; set; }
        public User User { get; set; } = null!;
    }
}
