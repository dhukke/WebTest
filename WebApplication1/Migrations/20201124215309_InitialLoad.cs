using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class InitialLoad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5093ea56-0453-45d0-b541-fcf3391790a4"), "Court 1" },
                    { new Guid("e0d9aa06-c626-4fab-9676-b1bad7d0f865"), "Court 2" },
                    { new Guid("96e15349-d8e7-4b4b-8e89-8ad1440680d3"), "Court 3" },
                    { new Guid("91bab092-37a9-4673-a7ed-ee3342afe980"), "Court 4" },
                    { new Guid("342e0a98-37ba-4c0a-b44f-17239045e7c3"), "Court 5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
