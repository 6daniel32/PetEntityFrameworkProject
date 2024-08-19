using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetEntityFrameworkProject.Migrations
{
    /// <inheritdoc />
    public partial class AddTestTraineeManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestTrainee_Test_TraineesTestId",
                table: "TestTrainee");

            migrationBuilder.RenameColumn(
                name: "TraineesTestId",
                table: "TestTrainee",
                newName: "TestsTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestTrainee_Test_TestsTestId",
                table: "TestTrainee",
                column: "TestsTestId",
                principalTable: "Test",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestTrainee_Test_TestsTestId",
                table: "TestTrainee");

            migrationBuilder.RenameColumn(
                name: "TestsTestId",
                table: "TestTrainee",
                newName: "TraineesTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestTrainee_Test_TraineesTestId",
                table: "TestTrainee",
                column: "TraineesTestId",
                principalTable: "Test",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
