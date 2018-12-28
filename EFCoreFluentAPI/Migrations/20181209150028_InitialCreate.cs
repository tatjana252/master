using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true, defaultValueSql: "CONVERT(date, GETDATE())"),
                    EnrollmentYear = table.Column<int>(nullable: true),
                    EnrollmentNum = table.Column<int>(nullable: true),
                    StudentDetails_Address = table.Column<string>(nullable: true),
                    StudentDetails_HighSchool = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorSubject",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false),
                    ProfessorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorSubject", x => new { x.ProfessorId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_ProfessorSubject_Person_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScientificArticle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProfessorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScientificArticle_Person_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
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

            migrationBuilder.CreateIndex(
                name: "IX_Grade_ProfessorId_SubjectId",
                table: "Grade",
                columns: new[] { "ProfessorId", "SubjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_Person_CityId",
                table: "Person",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorSubject_SubjectId",
                table: "ProfessorSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificArticle_ProfessorId",
                table: "ScientificArticle",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "ScientificArticle");

            migrationBuilder.DropTable(
                name: "ProfessorSubject");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
