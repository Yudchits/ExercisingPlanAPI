namespace ExercisingPlanAPI.Models
{
    public class CoachPupil
    {
        public int CoachId { get; set; }
        public int PupilId { get; set; }
        public User Coach { get; set; }
        public User Pupil { get; set; }
    }
}
