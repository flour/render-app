using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RenderApp.DataAccess.Postgres.Migrations
{
    public partial class init_someData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SomeData",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IntValue = table.Column<int>(type: "integer", nullable: false),
                    DecimalValue = table.Column<decimal>(type: "numeric", nullable: false),
                    DateTimeValue = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SomeData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SomeData");
        }
    }
}
