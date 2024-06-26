﻿// <auto-generated />
using ExercisingPlanAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExercisingPlanAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240404190947_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExercisingPlanAPI.Models.CoachPupil", b =>
                {
                    b.Property<int>("CoachId")
                        .HasColumnType("int");

                    b.Property<int>("PupilId")
                        .HasColumnType("int");

                    b.HasKey("CoachId", "PupilId");

                    b.HasIndex("PupilId");

                    b.ToTable("CoachPupils");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TargetMuscleGroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TargetMuscleGroupId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.ExercisingPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("ExercisingPlans");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.TargetMuscleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TargetMuscleGroups");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.UserSubscriber", b =>
                {
                    b.Property<int>("SubscriberId")
                        .HasColumnType("int");

                    b.Property<int>("SubscribeToId")
                        .HasColumnType("int");

                    b.HasKey("SubscriberId", "SubscribeToId");

                    b.HasIndex("SubscribeToId");

                    b.ToTable("UserSubscribers");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.WeekNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WeekNumbers");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.WeekPlan", b =>
                {
                    b.Property<int>("WeekNumberId")
                        .HasColumnType("int");

                    b.Property<int>("WeekdayId")
                        .HasColumnType("int");

                    b.Property<int>("ExercisingPlanId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.HasKey("WeekNumberId", "WeekdayId", "ExercisingPlanId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("ExercisingPlanId");

                    b.HasIndex("WeekdayId");

                    b.ToTable("WeekPlans");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.Weekday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Weekdays");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.CoachPupil", b =>
                {
                    b.HasOne("ExercisingPlanAPI.Models.User", "Coach")
                        .WithMany("CoachPupils")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ExercisingPlanAPI.Models.User", "Pupil")
                        .WithMany()
                        .HasForeignKey("PupilId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("Pupil");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.Exercise", b =>
                {
                    b.HasOne("ExercisingPlanAPI.Models.TargetMuscleGroup", "TargetMuscleGroup")
                        .WithMany("Exercises")
                        .HasForeignKey("TargetMuscleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TargetMuscleGroup");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.ExercisingPlan", b =>
                {
                    b.HasOne("ExercisingPlanAPI.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.UserRole", b =>
                {
                    b.HasOne("ExercisingPlanAPI.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExercisingPlanAPI.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.UserSubscriber", b =>
                {
                    b.HasOne("ExercisingPlanAPI.Models.User", "SubscribeTo")
                        .WithMany()
                        .HasForeignKey("SubscribeToId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ExercisingPlanAPI.Models.User", "Subscriber")
                        .WithMany("UserSubscribers")
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Subscriber");

                    b.Navigation("SubscribeTo");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.WeekPlan", b =>
                {
                    b.HasOne("ExercisingPlanAPI.Models.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExercisingPlanAPI.Models.ExercisingPlan", "ExercisingPlan")
                        .WithMany("WeekPlans")
                        .HasForeignKey("ExercisingPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExercisingPlanAPI.Models.WeekNumber", "WeekNumber")
                        .WithMany()
                        .HasForeignKey("WeekNumberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExercisingPlanAPI.Models.Weekday", "Weekday")
                        .WithMany()
                        .HasForeignKey("WeekdayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("ExercisingPlan");

                    b.Navigation("Weekday");

                    b.Navigation("WeekNumber");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.ExercisingPlan", b =>
                {
                    b.Navigation("WeekPlans");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.TargetMuscleGroup", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("ExercisingPlanAPI.Models.User", b =>
                {
                    b.Navigation("CoachPupils");

                    b.Navigation("UserRoles");

                    b.Navigation("UserSubscribers");
                });
#pragma warning restore 612, 618
        }
    }
}
