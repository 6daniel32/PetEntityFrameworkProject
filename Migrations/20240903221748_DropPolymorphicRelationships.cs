using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PetEntityFrameworkProject.Migrations
{
    /// <inheritdoc />
    public partial class DropPolymorphicRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTrainee_Supportables_CoursesSupportableId",
                table: "CourseTrainee");

            migrationBuilder.DropForeignKey(
                name: "FK_Supportables_SupportCentres_SupportCentreId",
                table: "Supportables");

            migrationBuilder.DropForeignKey(
                name: "FK_Supportables_SupportCentres_Test_SupportCentreId",
                table: "Supportables");

            migrationBuilder.DropForeignKey(
                name: "FK_TestTrainee_Supportables_TestsSupportableId",
                table: "TestTrainee");

            migrationBuilder.DropTable(
                name: "SupportableSupportCentres");

            migrationBuilder.DropTable(
                name: "SupportCentres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supportables",
                table: "Supportables");

            migrationBuilder.DropIndex(
                name: "IX_Supportables_SupportCentreId",
                table: "Supportables");

            migrationBuilder.DropIndex(
                name: "IX_Supportables_Test_SupportCentreId",
                table: "Supportables");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Supportables");

            migrationBuilder.DropColumn(
                name: "SupportCentreId",
                table: "Supportables");

            migrationBuilder.DropColumn(
                name: "Test_SupportCentreId",
                table: "Supportables");

            migrationBuilder.DropColumn(
                name: "Test_Title",
                table: "Supportables");

            migrationBuilder.RenameTable(
                name: "Supportables",
                newName: "Tests");

            migrationBuilder.RenameColumn(
                name: "TestsSupportableId",
                table: "TestTrainee",
                newName: "TestsTestId");

            migrationBuilder.RenameColumn(
                name: "CoursesSupportableId",
                table: "CourseTrainee",
                newName: "CoursesCourseId");

            migrationBuilder.RenameColumn(
                name: "SupportableId",
                table: "Tests",
                newName: "TestId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tests",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tests",
                table: "Tests",
                column: "TestId");

            migrationBuilder.CreateTable(
                name: "Addresses",
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
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CompanyId",
                table: "Addresses",
                column: "CompanyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTrainee_Courses_CoursesCourseId",
                table: "CourseTrainee",
                column: "CoursesCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestTrainee_Tests_TestsTestId",
                table: "TestTrainee",
                column: "TestsTestId",
                principalTable: "Tests",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTrainee_Courses_CoursesCourseId",
                table: "CourseTrainee");

            migrationBuilder.DropForeignKey(
                name: "FK_TestTrainee_Tests_TestsTestId",
                table: "TestTrainee");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tests",
                table: "Tests");

            migrationBuilder.RenameTable(
                name: "Tests",
                newName: "Supportables");

            migrationBuilder.RenameColumn(
                name: "TestsTestId",
                table: "TestTrainee",
                newName: "TestsSupportableId");

            migrationBuilder.RenameColumn(
                name: "CoursesCourseId",
                table: "CourseTrainee",
                newName: "CoursesSupportableId");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "Supportables",
                newName: "SupportableId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Supportables",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Supportables",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SupportCentreId",
                table: "Supportables",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Test_SupportCentreId",
                table: "Supportables",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Test_Title",
                table: "Supportables",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supportables",
                table: "Supportables",
                column: "SupportableId");

            migrationBuilder.CreateTable(
                name: "SupportCentres",
                columns: table => new
                {
                    SupportCentreId = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SupportableId = table.Column<Guid>(type: "uuid", nullable: true),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Workload = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportCentres", x => x.SupportCentreId);
                    table.ForeignKey(
                        name: "FK_SupportCentres_Supportables_SupportableId",
                        column: x => x.SupportableId,
                        principalTable: "Supportables",
                        principalColumn: "SupportableId");
                });

            migrationBuilder.CreateTable(
                name: "SupportableSupportCentres",
                columns: table => new
                {
                    SupportableId = table.Column<Guid>(type: "uuid", nullable: false),
                    SupportCentreId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportableSupportCentres", x => new { x.SupportableId, x.SupportCentreId });
                    table.ForeignKey(
                        name: "FK_SupportableSupportCentres_SupportCentres_SupportCentreId",
                        column: x => x.SupportCentreId,
                        principalTable: "SupportCentres",
                        principalColumn: "SupportCentreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupportableSupportCentres_Supportables_SupportableId",
                        column: x => x.SupportableId,
                        principalTable: "Supportables",
                        principalColumn: "SupportableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supportables_SupportCentreId",
                table: "Supportables",
                column: "SupportCentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Supportables_Test_SupportCentreId",
                table: "Supportables",
                column: "Test_SupportCentreId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportableSupportCentres_SupportCentreId",
                table: "SupportableSupportCentres",
                column: "SupportCentreId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportCentres_SupportableId",
                table: "SupportCentres",
                column: "SupportableId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTrainee_Supportables_CoursesSupportableId",
                table: "CourseTrainee",
                column: "CoursesSupportableId",
                principalTable: "Supportables",
                principalColumn: "SupportableId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supportables_SupportCentres_SupportCentreId",
                table: "Supportables",
                column: "SupportCentreId",
                principalTable: "SupportCentres",
                principalColumn: "SupportCentreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supportables_SupportCentres_Test_SupportCentreId",
                table: "Supportables",
                column: "Test_SupportCentreId",
                principalTable: "SupportCentres",
                principalColumn: "SupportCentreId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestTrainee_Supportables_TestsSupportableId",
                table: "TestTrainee",
                column: "TestsSupportableId",
                principalTable: "Supportables",
                principalColumn: "SupportableId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
