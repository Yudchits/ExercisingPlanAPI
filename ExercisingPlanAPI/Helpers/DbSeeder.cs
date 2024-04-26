using ExercisingPlanAPI.Data;
using ExercisingPlanAPI.Models;
using System.Collections.Generic;

namespace ExercisingPlanAPI.Helpers
{
    public class DbSeeder
    {
        private readonly DataContext _context;

        public DbSeeder(DataContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var coach1 = new User
            {
                FirstName = "Pavel",
                MiddleName = "Alexandrovich",
                LastName = "Yudchits"
            };
            var pupil1 = new User
            {
                FirstName = "Alex",
                MiddleName = "Petrovich",
                LastName = "Ivanov"
            };
            var pupil2 = new User
            {
                FirstName = "Oleg",
                MiddleName = "Ivanovich",
                LastName = "Borodach"
            };

            var monday = new Weekday
            {
                Name = "Monday"
            };
            var wednesday = new Weekday
            {
                Name = "Wednesday"
            };

            var back = new TargetMuscleGroup
            {
                Name = "Back"
            };
            var chest = new TargetMuscleGroup
            {
                Name = "Chest"
            };
            var shoulders = new TargetMuscleGroup
            {
                Name = "Shoulders"
            };
            var legs = new TargetMuscleGroup
            {
                Name = "Legs"
            };

            var exercisingPlan1 = new ExercisingPlan
            {
                Name = "Standard Gym",
                WeekPlans = new List<WeekPlan>()
                {
                    new WeekPlan
                    {
                        WeekNumber = 1,
                        Weekday = monday,
                        Exercise = new Exercise
                        {
                            Name = "Push Press",
                            Description = "Description for push press",
                            TargetMuscleGroup = shoulders
                        }
                    },
                    new WeekPlan 
                    {
                        WeekNumber = 1,
                        Weekday = monday,
                        Exercise = new Exercise
                        {
                            Name = "Lateral Raise",
                            Description = "Description for lateral raise",
                            TargetMuscleGroup = shoulders
                        }
                    },
                    new WeekPlan
                    {
                        WeekNumber = 2,
                        Weekday = monday,
                        Exercise = new Exercise
                        {
                            Name = "Barbell Curl",
                            Description = "Description for barbell curl",
                            TargetMuscleGroup = new TargetMuscleGroup
                            {
                                Name = "Biceps"
                            }
                        }
                    },
                    new WeekPlan
                    {
                        WeekNumber = 1,
                        Weekday = wednesday,
                        Exercise = new Exercise
                        {
                            Name = "Sit-To-Stand Calf Raise",
                            Description = "Description for sit-to-stand calf raise",
                            TargetMuscleGroup = legs
                        }
                    },
                    new WeekPlan
                    {
                        WeekNumber = 1,
                        Weekday = wednesday,
                        Exercise = new Exercise
                        {
                            Name = "Sprinter Calf Jumps",
                            Description = "Description for sprinter calf jumps",
                            TargetMuscleGroup = legs
                        }
                    },
                    new WeekPlan
                    {
                        WeekNumber = 2,
                        Weekday = wednesday,
                        Exercise = new Exercise
                        {
                            Name = "Squat",
                            Description = "Description for squat",
                            TargetMuscleGroup = legs
                        }
                    },
                },
                Owner = coach1
            };
            var exercisingPlan2 = new ExercisingPlan
            {
                Name = "Calicthenics",
                WeekPlans = new List<WeekPlan>()
                {
                    new WeekPlan
                    {   
                        WeekNumber = 1,
                        Weekday = monday,
                        Exercise = new Exercise
                        {
                            Name = "Pull Up",
                            Description = "Description for pull up",
                            TargetMuscleGroup = back
                        }
                    },
                    new WeekPlan
                    {   
                        WeekNumber = 1,
                        Weekday = monday,
                        Exercise = new Exercise
                        {
                            Name = "Muscle Up",
                            Description = "Description for muscle up",
                            TargetMuscleGroup = back
                        }
                    },
                    new WeekPlan
                    {   
                        WeekNumber = 2,
                        Weekday = monday,
                        Exercise = new Exercise
                        {
                            Name = "Dips",
                            Description = "Description for dips",
                            TargetMuscleGroup = chest
                        }
                    },
                    new WeekPlan
                    {   
                        WeekNumber = 2,  
                        Weekday = wednesday,
                        Exercise = new Exercise
                        {
                            Name = "Run",
                            Description = "Description for run",
                            TargetMuscleGroup = chest
                        }
                    }
                },
                Owner = coach1
            };

            var userPlan1 = new UserExercisingPlan
            {
                User = pupil1,
                ExercisingPlan = exercisingPlan1
            };

            var userPlan2 = new UserExercisingPlan
            {
                User = pupil1,
                ExercisingPlan = exercisingPlan2
            };

            var userSubscriber1 = new UserSubscriber
            {
                SubscribeTo = coach1,
                Subscriber = pupil1
            };
            var userSubscriber2 = new UserSubscriber
            {
                SubscribeTo = coach1,
                Subscriber = pupil2
            };

            var coachRole = new Role
            {
                Name = "Coach"
            };
            var pupilRole = new Role
            {
                Name = "Pupil"
            };

            var userRole1 = new UserRole
            {
                User = coach1,
                Role = coachRole
            };
            var userRole2 = new UserRole
            {
                User = pupil1,
                Role = pupilRole
            };
            var userRole3 = new UserRole
            {
                User = pupil2,
                Role = pupilRole
            };

            var coachPupil1 = new CoachPupil
            {
                Coach = coach1,
                Pupil = pupil1
            };
            var coachPupil2 = new CoachPupil
            {
                Coach = coach1,
                Pupil = pupil2
            };

            _context.UserExercisingPlans.AddRange(userPlan1);
            _context.UserExercisingPlans.AddRange(userPlan2);

            _context.UserSubscribers.Add(userSubscriber1);
            _context.UserSubscribers.Add(userSubscriber2);

            _context.UserRoles.Add(userRole1);
            _context.UserRoles.Add(userRole2);
            _context.UserRoles.Add(userRole3);

            _context.CoachPupils.Add(coachPupil1);
            _context.CoachPupils.Add(coachPupil2);

            _context.SaveChanges();
        }
    }
}
