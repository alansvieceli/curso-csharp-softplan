using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice.Whatevers.Repositories.Migrations
{
    public partial class FirstMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Whatever",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Whatever", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thing",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Value = table.Column<double>(nullable: false),
                    WhateverId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Thing_Whatever_WhateverId",
                        column: x => x.WhateverId,
                        principalTable: "Whatever",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Whatever",
                columns: new[] { "Id", "Name", "Time", "Type" },
                values: new object[] { new Guid("a7c6ec79-a64a-47fd-8b6a-7f56b6c67e14"), "Whatever", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some type" });

            migrationBuilder.InsertData(
                table: "Whatever",
                columns: new[] { "Id", "Name", "Time", "Type" },
                values: new object[] { new Guid("01d26bd4-3a1a-4f44-bec7-620b3c48b9b2"), "Whatever", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Another type" });

            migrationBuilder.InsertData(
                table: "Whatever",
                columns: new[] { "Id", "Name", "Time", "Type" },
                values: new object[] { new Guid("48d7a452-95e0-482a-9910-3d315aad375f"), "Whatever", new DateTime(2020, 4, 25, 12, 42, 11, 891, DateTimeKind.Local).AddTicks(4236), "More another type" });

            migrationBuilder.InsertData(
                table: "Whatever",
                columns: new[] { "Id", "Name", "Time", "Type" },
                values: new object[] { new Guid("a9d72406-ab03-49d5-af85-d90711a0c70e"), "Whatever", new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), "Once more another type" });

            migrationBuilder.CreateIndex(
                name: "IX_Thing_WhateverId",
                table: "Thing",
                column: "WhateverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Thing");

            migrationBuilder.DropTable(
                name: "Whatever");
        }
    }
}
