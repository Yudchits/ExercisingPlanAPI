﻿namespace ExercisingPlanAPI.Models
{
    public class UserSubscriber
    {
        public int SubscriberId { get; set; }
        public User Subscriber { get; set; }
        public int SubscribeToId { get; set; }
        public User SubscribeTo { get; set; }
    }
}
