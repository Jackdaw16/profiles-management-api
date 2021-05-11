using Microsoft.EntityFrameworkCore.Migrations;

namespace ProfileManagementApi.Migrations
{
    public partial class ProjectsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Profiles_ProfilesId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "ProfilesId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Profiles_ProfilesId",
                table: "Projects",
                column: "ProfilesId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Profiles_ProfilesId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "ProfilesId",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Profiles_ProfilesId",
                table: "Projects",
                column: "ProfilesId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
