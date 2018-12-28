using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.EF.Migrations
{
    public partial class PersonDateofBirthAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_City_CityId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorSubject_Subject_SubjectId",
                table: "ProfessorSubject");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.UniqueConstraint("AK_Cities_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    StudentsGrade = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => new { x.StudentId, x.ProfessorId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_Grades_Person_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_ProfessorSubject_ProfessorId_SubjectId",
                        columns: x => new { x.ProfessorId, x.SubjectId },
                        principalTable: "ProfessorSubject",
                        principalColumns: new[] { "ProfessorId", "SubjectId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_ProfessorId_SubjectId",
                table: "Grades",
                columns: new[] { "ProfessorId", "SubjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Cities_CityId",
                table: "Person",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorSubject_Subjects_SubjectId",
                table: "ProfessorSubject",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Cities_CityId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorSubject_Subjects_SubjectId",
                table: "ProfessorSubject");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Person");

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.UniqueConstraint("AK_City_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    ProfessorId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    StudentsGrade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => new { x.StudentId, x.ProfessorId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_Grade_Person_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grade_ProfessorSubject_ProfessorId_SubjectId",
                        columns: x => new { x.ProfessorId, x.SubjectId },
                        principalTable: "ProfessorSubject",
                        principalColumns: new[] { "ProfessorId", "SubjectId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grade_ProfessorId_SubjectId",
                table: "Grade",
                columns: new[] { "ProfessorId", "SubjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Person_City_CityId",
                table: "Person",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorSubject_Subject_SubjectId",
                table: "ProfessorSubject",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
