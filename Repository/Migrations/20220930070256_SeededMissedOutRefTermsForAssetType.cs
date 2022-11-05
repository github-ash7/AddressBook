using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class SeededMissedOutRefTermsForAssetType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RefTerm",
                columns: new[] { "Id", "Description", "Key" },
                values: new object[,]
                {
                    { new Guid("2cadf982-3566-46bb-b11d-bb39fbcc87f5"), "RefTerm key for ASSET_TYPE - JPEG image", "jpeg" },
                    { new Guid("346d765e-bf64-40ed-9fa5-9de57a2e5cc9"), "RefTerm key for ASSET_TYPE - PowerPoint presentation", "ppt" },
                    { new Guid("71cd4872-3568-4f94-a813-9d0e94bb85ca"), "RefTerm key for ASSET_TYPE - Portable Network Graphic image", "png" },
                    { new Guid("bc79dbc7-1d12-4dde-bc23-29d56a6e7ba7"), "RefTerm key for ASSET_TYPE - PowerPoint Open XML presentation", "pptx" },
                    { new Guid("bf361cf4-5ace-4af3-b0a8-4c3aae1e9be3"), "RefTerm key for ASSET_TYPE - Graphical Interchange Format image", "gif" },
                    { new Guid("e460009d-515a-4328-a540-cf07e16169f1"), "RefTerm key for ASSET_TYPE - Comma separated value file", "csv" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("2cadf982-3566-46bb-b11d-bb39fbcc87f5"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("346d765e-bf64-40ed-9fa5-9de57a2e5cc9"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("71cd4872-3568-4f94-a813-9d0e94bb85ca"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("bc79dbc7-1d12-4dde-bc23-29d56a6e7ba7"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("bf361cf4-5ace-4af3-b0a8-4c3aae1e9be3"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("e460009d-515a-4328-a540-cf07e16169f1"));
        }
    }
}
