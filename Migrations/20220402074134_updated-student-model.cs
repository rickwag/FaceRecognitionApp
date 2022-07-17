using Microsoft.EntityFrameworkCore.Migrations;

namespace FaceRecognitionApp.Migrations
{
    public partial class updatedstudentmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Lectures_LectureID",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "LectureID",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Lectures_LectureID",
                table: "Students",
                column: "LectureID",
                principalTable: "Lectures",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Lectures_LectureID",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "LectureID",
                table: "Students",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Lectures_LectureID",
                table: "Students",
                column: "LectureID",
                principalTable: "Lectures",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
