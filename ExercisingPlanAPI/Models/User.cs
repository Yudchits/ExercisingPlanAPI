using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExercisingPlanAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public ICollection<UserSubscriber> UserSubscribers { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<CoachPupil> CoachPupils { get; set; }
    }
}
