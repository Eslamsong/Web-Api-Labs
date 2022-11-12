using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DAL.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Patients");

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssuePatient",
                columns: table => new
                {
                    IssuesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuePatient", x => new { x.IssuesId, x.patientsId });
                    table.ForeignKey(
                        name: "FK_IssuePatient_Issues_IssuesId",
                        column: x => x.IssuesId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssuePatient_Patients_patientsId",
                        column: x => x.patientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Name", "PerformanceRate", "Salary", "Specialization" },
                values: new object[,]
                {
                    { new Guid("40caae98-b4db-46f4-80bb-4246e3776676"), "Nancy", 80, 40000.0, "Dermatology" },
                    { new Guid("5222383e-020b-4097-8914-286553ef34b6"), "Wael", 99, 90000.0, "Dentist" },
                    { new Guid("8b68c8d4-4d97-4089-ad2e-7485d0d83861"), "Nader", 100, 75000.0, "Pediartics" },
                    { new Guid("c70bbac3-2fec-46bc-95bc-9989d80f471b"), "MOhammed", 80, 95000.0, "opthomalogy" },
                    { new Guid("d4ec6c1b-ed19-4b10-a230-c0d0046b5389"), "Ahmed", 90, 30000.0, "Cardiology" }
                });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("05a73b2b-c16e-4b9f-adcf-2a61772196c0"), "Headache" },
                    { new Guid("0cb2a78e-6823-4322-a8b4-a4ce0a16a511"), "Shawn" },
                    { new Guid("50e70766-3d34-4298-8dca-d2a6d574fedc"), "Stress" },
                    { new Guid("918f8e6f-79b9-48f8-a137-172ffd22caa7"), "Arnold" },
                    { new Guid("97398bac-ee33-456d-b150-b3d464a94ad6"), "Cold" },
                    { new Guid("fa453ef9-9b60-45f1-a8a6-b50a3f22fcbe"), "Michal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssuePatient_patientsId",
                table: "IssuePatient",
                column: "patientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssuePatient");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("40caae98-b4db-46f4-80bb-4246e3776676"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("5222383e-020b-4097-8914-286553ef34b6"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("8b68c8d4-4d97-4089-ad2e-7485d0d83861"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("c70bbac3-2fec-46bc-95bc-9989d80f471b"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("d4ec6c1b-ed19-4b10-a230-c0d0046b5389"));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
