using Microsoft.EntityFrameworkCore.Migrations;

namespace ExercisingPlanAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TargetMuscleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetMuscleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weekdays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weekdays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeekNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetMuscleGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_TargetMuscleGroups_TargetMuscleGroupId",
                        column: x => x.TargetMuscleGroupId,
                        principalTable: "TargetMuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoachPupils",
                columns: table => new
                {
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    PupilId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachPupils", x => new { x.CoachId, x.PupilId });
                    table.ForeignKey(
                        name: "FK_CoachPupils_Users_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CoachPupils_Users_PupilId",
                        column: x => x.PupilId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExercisingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisingPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExercisingPlans_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSubscribers",
                columns: table => new
                {
                    SubscriberId = table.Column<int>(type: "int", nullable: false),
                    SubscribeToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubscribers", x => new { x.SubscriberId, x.SubscribeToId });
                    table.ForeignKey(
                        name: "FK_UserSubscribers_Users_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSubscribers_Users_SubscribeToId",
                        column: x => x.SubscribeToId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WeekPlans",
                columns: table => new
                {
                    WeekNumberId = table.Column<int>(type: "int", nullable: false),
                    WeekdayId = table.Column<int>(type: "int", nullable: false),
                    ExercisingPlanId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekPlans", x => new { x.WeekNumberId, x.WeekdayId, x.ExercisingPlanId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_WeekPlans_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeekPlans_ExercisingPlans_ExercisingPlanId",
                        column: x => x.ExercisingPlanId,
                        principalTable: "ExercisingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeekPlans_Weekdays_WeekdayId",
                        column: x => x.WeekdayId,
                        principalTable: "Weekdays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeekPlans_WeekNumbers_WeekNumberId",
                        column: x => x.WeekNumberId,
                        principalTable: "WeekNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoachPupils_PupilId",
                table: "CoachPupils",
                column: "PupilId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TargetMuscleGroupId",
                table: "Exercises",
                column: "TargetMuscleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisingPlans_OwnerId",
                table: "ExercisingPlans",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscribers_SubscribeToId",
                table: "UserSubscribers",
                column: "SubscribeToId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekPlans_ExerciseId",
                table: "WeekPlans",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekPlans_ExercisingPlanId",
                table: "WeekPlans",
                column: "ExercisingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekPlans_WeekdayId",
                table: "WeekPlans",
                column: "WeekdayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoachPupils");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserSubscribers");

            migrationBuilder.DropTable(
                name: "WeekPlans");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "ExercisingPlans");

            migrationBuilder.DropTable(
                name: "Weekdays");

            migrationBuilder.DropTable(
                name: "WeekNumbers");

            migrationBuilder.DropTable(
                name: "TargetMuscleGroups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
