using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetEntityFrameworkProject.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTimestamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Companies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "UpdatedAt",
                table: "Trainees",
                type: "bytea",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "UpdatedAt",
                table: "Companies",
                type: "bytea",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
