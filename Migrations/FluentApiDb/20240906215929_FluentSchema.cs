using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PetEntityFrameworkProject.Migrations.FluentApiDb
{
    /// <inheritdoc />
    public partial class FluentSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FluentCompanies",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentCompanies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "FluentTests",
                columns: table => new
                {
                    TestId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentTests", x => x.TestId);
                });

            migrationBuilder.CreateTable(
                name: "FluentAddresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentAddresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_FluentAddresses_FluentCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "FluentCompanies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FluentTrainees",
                columns: table => new
                {
                    TraineeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentTrainees", x => x.TraineeId);
                    table.ForeignKey(
                        name: "FK_FluentTrainees_FluentCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "FluentCompanies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FluentTraineeTest",
                columns: table => new
                {
                    TestId = table.Column<Guid>(type: "uuid", nullable: false),
                    TraineeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentTraineeTest", x => new { x.TestId, x.TraineeId });
                    table.ForeignKey(
                        name: "FK_FluentTraineeTest_FluentTests_TestId",
                        column: x => x.TestId,
                        principalTable: "FluentTests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FluentTraineeTest_FluentTrainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "FluentTrainees",
                        principalColumn: "TraineeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FluentAddresses_CompanyId",
                table: "FluentAddresses",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FluentTrainees_CompanyId",
                table: "FluentTrainees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_FluentTraineeTest_TraineeId",
                table: "FluentTraineeTest",
                column: "TraineeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FluentAddresses");

            migrationBuilder.DropTable(
                name: "FluentTraineeTest");

            migrationBuilder.DropTable(
                name: "FluentTests");

            migrationBuilder.DropTable(
                name: "FluentTrainees");

            migrationBuilder.DropTable(
                name: "FluentCompanies");
        }
    }
}
