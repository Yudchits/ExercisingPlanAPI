using ExercisingPlanAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExercisingPlanAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<CoachPupil> CoachPupils { get; set; }
        public DbSet<ExercisingPlan> ExercisingPlans { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserSubscriber> UserSubscribers { get; set; }

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
                .HasOne(us => us.User)
                .WithMany()
                .HasForeignKey(us => us.SubscribeToId)
                .OnDelete(DeleteBehavior.NoAction);

            // UserRole relationship
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany()
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Ignore<ExercisingPlan>();
        }
    }
}
