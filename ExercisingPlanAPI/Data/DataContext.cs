using ExercisingPlanAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExercisingPlanAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<CoachPupil> CoachPupils { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExercisingPlan> ExercisingPlans { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TargetMuscleGroup> TargetMuscleGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserSubscriber> UserSubscribers { get; set; }
        public DbSet<Weekday> Weekdays { get; set; }
        public DbSet<WeekNumber> WeekNumbers { get; set; }
        public DbSet<WeekPlan> WeekPlans { get; set; }
        public DbSet<UserExercisingPlan> UserExercisingPlans { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // CoachPupil relationship
            modelBuilder.Entity<CoachPupil>()
                .HasKey(cp => new { cp.CoachId, cp.PupilId });

            modelBuilder.Entity<CoachPupil>()
                .HasOne(cp => cp.Coach)
                .WithMany(u => u.CoachPupils)
                .HasForeignKey(cp => cp.CoachId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CoachPupil>()
                .HasOne(cp => cp.Pupil)
                .WithMany() 
                .HasForeignKey(cp => cp.PupilId)
                .OnDelete(DeleteBehavior.NoAction);

            // UserSubscriber relationship
            modelBuilder.Entity<UserSubscriber>()
                .HasKey(us => new { us.SubscriberId, us.SubscribeToId });

            modelBuilder.Entity<UserSubscriber>()
                .HasOne(us => us.Subscriber)
                .WithMany(u => u.UserSubscribers)
                .HasForeignKey(us => us.SubscriberId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserSubscriber>()
                .HasOne(us => us.SubscribeTo)
                .WithMany()
                .HasForeignKey(us => us.SubscribeToId)
                .OnDelete(DeleteBehavior.NoAction);

            // UserRole relationship
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // WeekPlan relationship
            modelBuilder.Entity<WeekPlan>()
                .HasKey(wp => new { wp.WeekNumberId, wp.WeekdayId, wp.ExercisingPlanId, wp.ExerciseId });

            modelBuilder.Entity<WeekPlan>()
                .HasOne(wp => wp.ExercisingPlan)
                .WithMany(ep => ep.WeekPlans)
                .HasForeignKey(we => we.ExercisingPlanId);

            modelBuilder.Entity<WeekPlan>()
                .HasOne(wp => wp.WeekNumber)
                .WithMany()
                .HasForeignKey(wwe => wwe.WeekNumberId);

            modelBuilder.Entity<WeekPlan>()
                .HasOne(wp => wp.Weekday)
                .WithMany()
                .HasForeignKey(we => we.WeekdayId);

            modelBuilder.Entity<WeekPlan>()
                .HasOne(wp => wp.Exercise)
                .WithMany()
                .HasForeignKey(we => we.ExerciseId);

            // UserExercisingPlan relationship
            modelBuilder.Entity<UserExercisingPlan>()
                .HasKey(ue => new { ue.UserId, ue.ExercisingPlanId });

            modelBuilder.Entity<UserExercisingPlan>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserExercisingPlans)
                .HasForeignKey(ue => ue.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserExercisingPlan>()
                .HasOne(ue => ue.ExercisingPlan)
                .WithMany(e => e.UserExercisingPlans)
                .HasForeignKey(ue => ue.ExercisingPlanId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
