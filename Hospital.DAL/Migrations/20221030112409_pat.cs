using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DAL.Migrations
{
    public partial class pat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: new Guid("05a73b2b-c16e-4b9f-adcf-2a61772196c0"));

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: new Guid("0cb2a78e-6823-4322-a8b4-a4ce0a16a511"));

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: new Guid("50e70766-3d34-4298-8dca-d2a6d574fedc"));

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: new Guid("918f8e6f-79b9-48f8-a137-172ffd22caa7"));

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: new Guid("97398bac-ee33-456d-b150-b3d464a94ad6"));

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: new Guid("fa453ef9-9b60-45f1-a8a6-b50a3f22fcbe"));

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Name", "PerformanceRate", "Salary", "Specialization" },
                values: new object[,]
                {
                    { new Guid("0493f928-a4b7-40de-96d2-fea87cc3ef52"), "Ahmed", 90, 30000.0, "Cardiology" },
                    { new Guid("1e2a5653-5b98-44d4-b598-5a458459d468"), "MOhammed", 80, 95000.0, "opthomalogy" },
                    { new Guid("449498aa-da70-40cd-8686-6df2c9958897"), "Wael", 99, 90000.0, "Dentist" },
                    { new Guid("7435482d-a009-4342-aa04-423859061537"), "Nader", 100, 75000.0, "Pediartics" },
                    { new Guid("e992ddc0-30b1-4990-81f8-42fc8cc3e4e1"), "Nancy", 80, 40000.0, "Dermatology" }
                });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00f8c445-5957-432c-9dc0-88c8b1813db1"), "Cold" },
                    { new Guid("c094f123-d49f-437a-91d8-d38049e84eb8"), "Stress" },
                    { new Guid("e3809c15-7dfc-46f3-9b8b-edd5db3fd572"), "Headache" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("65ab7d82-9421-498f-9c36-2821cada230b"), "Michal" },
                    { new Guid("8fda8cb7-7f3a-4a80-b0a0-b66c5f901276"), "Shawn" },
                    { new Guid("efa74df1-ae17-4e6c-8bee-20caad7e4d2e"), "Arnold" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("0493f928-a4b7-40de-96d2-fea87cc3ef52"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("1e2a5653-5b98-44d4-b598-5a458459d468"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("449498aa-da70-40cd-8686-6df2c9958897"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("7435482d-a009-4342-aa04-423859061537"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("e992ddc0-30b1-4990-81f8-42fc8cc3e4e1"));

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: new Guid("00f8c445-5957-432c-9dc0-88c8b1813db1"));

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: new Guid("c094f123-d49f-437a-91d8-d38049e84eb8"));

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: new Guid("e3809c15-7dfc-46f3-9b8b-edd5db3fd572"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("65ab7d82-9421-498f-9c36-2821cada230b"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("8fda8cb7-7f3a-4a80-b0a0-b66c5f901276"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("efa74df1-ae17-4e6c-8bee-20caad7e4d2e"));

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
        }
    }
}
