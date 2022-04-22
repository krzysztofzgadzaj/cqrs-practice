using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FullCqrsApp.Migrations
{
    public partial class WriteDatabaseCreatedAndUsersTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "WriteSchema");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "WriteSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "WriteSchema");
        }
    }
}
