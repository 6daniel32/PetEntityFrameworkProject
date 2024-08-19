using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetEntityFrameworkProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    TraineeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.TraineeId);
                    table.ForeignKey(
                        name: "FK_Trainees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTrainee",
                columns: table => new
                {
                    CoursesSupportableId = table.Column<Guid>(type: "uuid", nullable: false),
                    TraineesTraineeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTrainee", x => new { x.CoursesSupportableId, x.TraineesTraineeId });
                    table.ForeignKey(
                        name: "FK_CourseTrainee_Trainees_TraineesTraineeId",
                        column: x => x.TraineesTraineeId,
                        principalTable: "Trainees",
                        principalColumn: "TraineeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supportables",
                columns: table => new
                {
                    SupportableId = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SupportCentreId = table.Column<Guid>(type: "uuid", nullable: true),
                    Test_Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Test_SupportCentreId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supportables", x => x.SupportableId);
                });

            migrationBuilder.CreateTable(
                name: "SupportCentres",
                columns: table => new
                {
                    SupportCentreId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Language = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Workload = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SupportableId = table.Column<Guid>(type: "uuid", nullable: true)
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
                name: "TestTrainee",
                columns: table => new
                {
                    TestsSupportableId = table.Column<Guid>(type: "uuid", nullable: false),
                    TraineesTraineeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTrainee", x => new { x.TestsSupportableId, x.TraineesTraineeId });
                    table.ForeignKey(
                        name: "FK_TestTrainee_Supportables_TestsSupportableId",
                        column: x => x.TestsSupportableId,
                        principalTable: "Supportables",
                        principalColumn: "SupportableId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestTrainee_Trainees_TraineesTraineeId",
                        column: x => x.TraineesTraineeId,
                        principalTable: "Trainees",
                        principalColumn: "TraineeId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_CourseTrainee_TraineesTraineeId",
                table: "CourseTrainee",
                column: "TraineesTraineeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TestTrainee_TraineesTraineeId",
                table: "TestTrainee",
                column: "TraineesTraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_CompanyId",
                table: "Trainees",
                column: "CompanyId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupportCentres_Supportables_SupportableId",
                table: "SupportCentres");

            migrationBuilder.DropTable(
                name: "CourseTrainee");

            migrationBuilder.DropTable(
                name: "SupportableSupportCentres");

            migrationBuilder.DropTable(
                name: "TestTrainee");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Supportables");

            migrationBuilder.DropTable(
                name: "SupportCentres");
        }
    }
}
