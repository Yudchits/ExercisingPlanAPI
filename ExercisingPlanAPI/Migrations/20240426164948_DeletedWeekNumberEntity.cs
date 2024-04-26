using Microsoft.EntityFrameworkCore.Migrations;

namespace ExercisingPlanAPI.Migrations
{
    public partial class DeletedWeekNumberEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeekPlans_WeekNumbers_WeekNumberId",
                table: "WeekPlans");

            migrationBuilder.DropTable(
                name: "WeekNumbers");

            migrationBuilder.RenameColumn(
                name: "WeekNumberId",
                table: "WeekPlans",
                newName: "WeekNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeekNumber",
                table: "WeekPlans",
                newName: "WeekNumberId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_WeekPlans_WeekNumbers_WeekNumberId",
                table: "WeekPlans",
                column: "WeekNumberId",
                principalTable: "WeekNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
