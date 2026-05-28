using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSoft.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCampaignsAndPractitionerAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Beloeb",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "AutorisationsType",
                table: "Practitioners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AnvendtRabatType",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Pris",
                table: "Appointments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountProcent = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
                    ValidFor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Beloeb",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AutorisationsType",
                table: "Practitioners");

            migrationBuilder.DropColumn(
                name: "AnvendtRabatType",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Pris",
                table: "Appointments");
        }
    }
}
