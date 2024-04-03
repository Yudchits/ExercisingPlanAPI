using Microsoft.EntityFrameworkCore.Migrations;

namespace ExercisingPlanAPI.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExercisingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "TargetMuscleGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetMuscleGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weekday",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weekday", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetMuscleGroupIp = table.Column<int>(type: "int", nullable: false),
                    TargetMuscleGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_TargetMuscleGroup_TargetMuscleGroupId",
                        column: x => x.TargetMuscleGroupId,
                        principalTable: "TargetMuscleGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeekdayExercise",
                columns: table => new
                {
                    WeekdayId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    ExercisingPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekdayExercise", x => new { x.WeekdayId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_WeekdayExercise_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WeekdayExercise_ExercisingPlans_ExercisingPlanId",
                        column: x => x.ExercisingPlanId,
                        principalTable: "ExercisingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeekdayExercise_Weekday_WeekdayId",
                        column: x => x.WeekdayId,
                        principalTable: "Weekday",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_TargetMuscleGroupId",
                table: "Exercise",
                column: "TargetMuscleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisingPlans_OwnerId",
                table: "ExercisingPlans",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekdayExercise_ExerciseId",
                table: "WeekdayExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekdayExercise_ExercisingPlanId",
                table: "WeekdayExercise",
                column: "ExercisingPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeekdayExercise");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "ExercisingPlans");

            migrationBuilder.DropTable(
                name: "Weekday");

            migrationBuilder.DropTable(
                name: "TargetMuscleGroup");
        }
    }
}
