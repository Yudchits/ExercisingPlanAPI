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
            // CoachPupil
            var coach = new User
            {
                FirstName = "Pavel",
                MiddleName = "Alexandrovich",
                LastName = "Yudchits"
            };

            var pupil1 = new User
            {
                FirstName = "Alex",
                MiddleName = "Sergeevich",
                LastName = "Ivanov"
            };

            var pupil2 = new User
            {
                FirstName = "Ivan",
                MiddleName = "Alexeevich",
                LastName = "Petrov"
            };

            var coachPupils = new List<CoachPupil>()
            {
                new CoachPupil
                {
                    Coach = coach,
                    Pupil = pupil1
                },
                new CoachPupil
                {
                    Coach = coach,
                    Pupil = pupil2
                }
            };

            _context.CoachPupils.AddRange(coachPupils);

            // UserSubscriber
            var userSubscribers = new List<UserSubscriber>()
            {
                new UserSubscriber
                {
                    Subscriber = pupil1,
                    User = coach
                },
                new UserSubscriber
                {
                    Subscriber = pupil2,
                    User = coach
                },
                new UserSubscriber
                {
                    Subscriber = new User
                    {
                        FirstName = "Petr",
                        MiddleName = "Ivanovich",
                        LastName = "Petrov"
                    },
                    User = coach
                }
            };

            _context.UserSubscribers.AddRange(userSubscribers);

            var userRoles = new List<UserRole>()
            {
                new UserRole
                {
                    User = coach,
                    Role = new Role
                    {
                        Name = "Coach"
                    }
                },
                new UserRole
                {
                    User = pupil1,
                    Role = new Role
                    {
                        Name = "Pupil"
                    }
                },
                new UserRole
                {
                    User = pupil2,
                    Role = new Role
                    {
                        Name = "Pupil"
                    }
                }
            };

            _context.UserRoles.AddRange(userRoles);

            _context.SaveChanges();
        }
    }
}
