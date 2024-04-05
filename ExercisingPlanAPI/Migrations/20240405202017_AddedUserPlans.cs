using Microsoft.EntityFrameworkCore.Migrations;

namespace ExercisingPlanAPI.Migrations
{
    public partial class AddedUserPlans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserExercisingPlans",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExercisingPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExercisingPlans", x => new { x.UserId, x.ExercisingPlanId });
                    table.ForeignKey(
                        name: "FK_UserExercisingPlans_ExercisingPlans_ExercisingPlanId",
                        column: x => x.ExercisingPlanId,
                        principalTable: "ExercisingPlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserExercisingPlans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserExercisingPlans_ExercisingPlanId",
                table: "UserExercisingPlans",
                column: "ExercisingPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserExercisingPlans");
        }
    }
}
