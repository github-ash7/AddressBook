using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AfterSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RefSet",
                columns: new[] { "Id", "Key" },
                values: new object[,]
                {
                    { new Guid("96388fb1-74c2-4915-88d0-c1a2d9b8600d"), "ADDRESS_TYPE" },
                    { new Guid("a929dfdc-207b-4578-85e9-20edf77e353f"), "PHONE_NUMBER_TYPE" },
                    { new Guid("f3adda1e-ee6b-41f8-9b26-d23d135b6893"), "EMAIL_ADDRESS_TYPE" }
                });

            migrationBuilder.InsertData(
                table: "RefTerm",
                columns: new[] { "Id", "Description", "Key" },
                values: new object[,]
                {
                    { new Guid("1bb955a3-5fef-428a-a763-97eadb9e46ac"), "RefTerm key for EMAIL_ADDRESS_TYPE, ADDRESS_TYPE and PHONE_NUMBER_TYPE", "WORK" },
                    { new Guid("aabe0ac9-35e4-45af-ab6f-48bcbe16eba1"), "RefTerm key for PHONE_NUMBER_TYPE", "ALTERNATE" },
                    { new Guid("ad0cfe12-3b16-47ae-b9e2-c534bc57686d"), "RefTerm key for EMAIL_ADDRESS_TYPE, ADDRESS_TYPE and PHONE_NUMBER_TYPE", "PERSONAL" }
                });

            migrationBuilder.InsertData(
                table: "SetRefTerm",
                columns: new[] { "Id", "RefSetId", "RefTermId" },
                values: new object[,]
                {
                    { new Guid("163a753c-4ba3-4ef3-9e93-09071c715389"), new Guid("96388fb1-74c2-4915-88d0-c1a2d9b8600d"), new Guid("1bb955a3-5fef-428a-a763-97eadb9e46ac") },
                    { new Guid("4fbd7121-54fa-4912-b977-6637867938a4"), new Guid("f3adda1e-ee6b-41f8-9b26-d23d135b6893"), new Guid("ad0cfe12-3b16-47ae-b9e2-c534bc57686d") },
                    { new Guid("5e1d7a3b-4688-4f8d-8512-4878f214304f"), new Guid("f3adda1e-ee6b-41f8-9b26-d23d135b6893"), new Guid("1bb955a3-5fef-428a-a763-97eadb9e46ac") },
                    { new Guid("633a4b3b-eefd-4d8c-9d32-47d3511ad89e"), new Guid("a929dfdc-207b-4578-85e9-20edf77e353f"), new Guid("ad0cfe12-3b16-47ae-b9e2-c534bc57686d") },
                    { new Guid("789bf1c7-7e43-4f8b-bf2e-a3dd2397794b"), new Guid("a929dfdc-207b-4578-85e9-20edf77e353f"), new Guid("aabe0ac9-35e4-45af-ab6f-48bcbe16eba1") },
                    { new Guid("c92f9237-d91b-4f00-9c79-4e3a9c3bdb26"), new Guid("96388fb1-74c2-4915-88d0-c1a2d9b8600d"), new Guid("ad0cfe12-3b16-47ae-b9e2-c534bc57686d") },
                    { new Guid("ecdac221-1e9b-4a96-bf61-b1503ceb87eb"), new Guid("a929dfdc-207b-4578-85e9-20edf77e353f"), new Guid("1bb955a3-5fef-428a-a763-97eadb9e46ac") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SetRefTerm",
                keyColumn: "Id",
                keyValue: new Guid("163a753c-4ba3-4ef3-9e93-09071c715389"));

            migrationBuilder.DeleteData(
                table: "SetRefTerm",
                keyColumn: "Id",
                keyValue: new Guid("4fbd7121-54fa-4912-b977-6637867938a4"));

            migrationBuilder.DeleteData(
                table: "SetRefTerm",
                keyColumn: "Id",
                keyValue: new Guid("5e1d7a3b-4688-4f8d-8512-4878f214304f"));

            migrationBuilder.DeleteData(
                table: "SetRefTerm",
                keyColumn: "Id",
                keyValue: new Guid("633a4b3b-eefd-4d8c-9d32-47d3511ad89e"));

            migrationBuilder.DeleteData(
                table: "SetRefTerm",
                keyColumn: "Id",
                keyValue: new Guid("789bf1c7-7e43-4f8b-bf2e-a3dd2397794b"));

            migrationBuilder.DeleteData(
                table: "SetRefTerm",
                keyColumn: "Id",
                keyValue: new Guid("c92f9237-d91b-4f00-9c79-4e3a9c3bdb26"));

            migrationBuilder.DeleteData(
                table: "SetRefTerm",
                keyColumn: "Id",
                keyValue: new Guid("ecdac221-1e9b-4a96-bf61-b1503ceb87eb"));

            migrationBuilder.DeleteData(
                table: "RefSet",
                keyColumn: "Id",
                keyValue: new Guid("96388fb1-74c2-4915-88d0-c1a2d9b8600d"));

            migrationBuilder.DeleteData(
                table: "RefSet",
                keyColumn: "Id",
                keyValue: new Guid("a929dfdc-207b-4578-85e9-20edf77e353f"));

            migrationBuilder.DeleteData(
                table: "RefSet",
                keyColumn: "Id",
                keyValue: new Guid("f3adda1e-ee6b-41f8-9b26-d23d135b6893"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("1bb955a3-5fef-428a-a763-97eadb9e46ac"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("aabe0ac9-35e4-45af-ab6f-48bcbe16eba1"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("ad0cfe12-3b16-47ae-b9e2-c534bc57686d"));
        }
    }
}
