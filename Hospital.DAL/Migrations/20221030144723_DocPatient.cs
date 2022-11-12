using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DAL.Migrations
{
    public partial class DocPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "Doc_Id",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "doctorId",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Name", "PerformanceRate", "Salary", "Specialization" },
                values: new object[,]
                {
                    { new Guid("78a29580-f456-445c-88be-a918f17b1994"), "Wael", 99, 90000.0, "Dentist" },
                    { new Guid("8f39d552-dcf1-4ab2-b2df-c9704620ce65"), "Ahmed", 90, 30000.0, "Cardiology" },
                    { new Guid("b21a2b61-0e8b-4c4f-9b7b-1f887f1dbeee"), "MOhammed", 80, 95000.0, "opthomalogy" },
                    { new Guid("e037fcfb-faf8-4e9d-a336-660de3b2e10f"), "Nader", 100, 75000.0, "Pediartics" },
                    { new Guid("f5fdacad-1e82-4974-ab0d-184acb7f1460"), "Nancy", 80, 40000.0, "Dermatology" }
                });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("01c92841-985d-44ea-8a5a-fbc10d4e6ca1"), "Headache" },
                    { new Guid("a9229472-e62f-4991-842a-8d2cc3b849a5"), "Cold" },
                    { new Guid("ba1e0658-1624-4c10-ba98-e3b60bafe52d"), "Stress" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Doc_Id", "Name", "doctorId" },
                values: new object[,]
                {
                    { new Guid("0665d558-fdd1-4f53-bc3c-18fcfbee8fd2"), new Guid("00000000-0000-0000-0000-000000000000"), "Michal", null },
                    { new Guid("136dd994-5616-419f-9f16-b538c42c63b7"), new Guid("00000000-0000-0000-0000-000000000000"), "Shawn", null },
                    { new Guid("aa84338d-d741-44d6-bbea-f5de82225344"), new Guid("00000000-0000-0000-0000-000000000000"), "Arnold", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_doctorId",
                table: "Patients",
                column: "doctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Doctors_doctorId",
                table: "Patients",
                column: "doctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Doctors_doctorId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_doctorId",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("78a29580-f456-445c-88be-a918f17b1994"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("8f39d552-dcf1-4ab2-b2df-c9704620ce65"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("b21a2b61-0e8b-4c4f-9b7b-1f887f1dbeee"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("e037fcfb-faf8-4e9d-a336-660de3b2e10f"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("f5fdacad-1e82-4974-ab0d-184acb7f1460"));

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: new Guid("01c92841-985d-44ea-8a5a-fbc10d4e6ca1"));

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: new Guid("a9229472-e62f-4991-842a-8d2cc3b849a5"));

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: new Guid("ba1e0658-1624-4c10-ba98-e3b60bafe52d"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("0665d558-fdd1-4f53-bc3c-18fcfbee8fd2"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("136dd994-5616-419f-9f16-b538c42c63b7"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("aa84338d-d741-44d6-bbea-f5de82225344"));

            migrationBuilder.DropColumn(
                name: "Doc_Id",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "doctorId",
                table: "Patients");

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
    }
}
