using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class SeededRefTermForAssetAndAddedRefTermIdInAssetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RefTermId",
                table: "Asset",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "RefSet",
                columns: new[] { "Id", "Key" },
                values: new object[] { new Guid("dc0dbb4a-fc40-40a6-a2c7-a9b7d721b572"), "ASSET_TYPE" });

            migrationBuilder.InsertData(
                table: "RefTerm",
                columns: new[] { "Id", "Description", "Key" },
                values: new object[,]
                {
                    { new Guid("16f0ae0e-0bda-4918-b8b2-ce8dddfb8c34"), "RefTerm key for ASSET_TYPE - Audio Video Interleave File", "avi" },
                    { new Guid("30b738e9-ae98-4f0b-9a7c-2d2eb75b2d81"), "RefTerm key for ASSET_TYPE - Windows Media audio file", "wma" },
                    { new Guid("4f0ad96f-69e1-4ac3-a235-f729b270fbe3"), "RefTerm key for ASSET_TYPE - Windows Media Video File", "wmv" },
                    { new Guid("75ddb934-6483-40dc-b8f9-f2bae2b378de"), "RefTerm key for ASSET_TYPE - WAVE file", "wav" },
                    { new Guid("7ac94584-fb91-4a4e-ba09-54490f2c1ddb"), "RefTerm key for ASSET_TYPE - Microsoft Word file", "docx" },
                    { new Guid("7d8f9798-7696-4d74-b86c-9a4ba9126c8f"), "RefTerm key for ASSET_TYPE - Microsoft Word file", "doc" },
                    { new Guid("826469ff-6e5f-4f04-b305-627b5e98120d"), "RefTerm key for ASSET_TYPE - PDF file", "pdf" },
                    { new Guid("82ce80fa-fbc8-4d4c-9392-fcef56a55855"), "RefTerm key for ASSET_TYPE - Microsoft Works spreadsheet file", "xlr" },
                    { new Guid("884f3f45-566a-4749-8513-ff133f109b7c"), "RefTerm key for ASSET_TYPE - Java Archive file", "jar" },
                    { new Guid("9359560b-df94-4936-b905-8be51cd6b492"), "RefTerm key for ASSET_TYPE - MP3 audio file", "mp3" },
                    { new Guid("9c1cdc55-6b41-4a07-b6f7-41d8fafef1cc"), "RefTerm key for ASSET_TYPE - Plain text file", "txt" },
                    { new Guid("a88d7ccc-3358-488d-a962-b7cc545f1052"), "RefTerm key for ASSET_TYPE - Binary file", "bin" },
                    { new Guid("c8578ed2-83aa-40ff-82df-cbd415d53b93"), "RefTerm key for ASSET_TYPE - Microsoft Excel Open XML spreadsheet file", "xlsx" },
                    { new Guid("c86fd1ee-15ef-45e1-8c1a-00179473c4b5"), "RefTerm key for ASSET_TYPE - Matroska Multimedia Container", "mkv" },
                    { new Guid("cac1a75c-0061-4e2d-a48b-1855cfc28bb3"), "RefTerm key for ASSET_TYPE - Microsoft Excel file", "xls" },
                    { new Guid("d688b39c-b74b-480e-a244-3b9fef95e18a"), "RefTerm key for ASSET_TYPE - MPEG-4 Video File", "mp4" },
                    { new Guid("e07891b8-1612-4d37-8f12-7ce78e0c6d71"), "RefTerm key for ASSET_TYPE - Audio Interchange audio file", "aif" },
                    { new Guid("e1c93602-8c17-4e4e-9fa5-b771ced61f42"), "RefTerm key for ASSET_TYPE - Python file", "py" },
                    { new Guid("e39c6b69-8afc-439b-a6a0-0c474cf0003f"), "RefTerm key for ASSET_TYPE - CD audio track file", "cda" },
                    { new Guid("ebbfb36d-2826-4d6e-bdf9-b1a7774cf484"), "RefTerm key for ASSET_TYPE - Executable file", "exe" },
                    { new Guid("f638f66f-28c1-4c2b-a014-bf6ffac25233"), "RefTerm key for ASSET_TYPE - Android package file", "apk" },
                    { new Guid("f8ebbf1c-f41c-48d9-87b0-86b70c7bbf73"), "RefTerm key for ASSET_TYPE - Apple QuickTime movie File", "mov" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_RefTermId",
                table: "Asset",
                column: "RefTermId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_RefTerm_RefTermId",
                table: "Asset",
                column: "RefTermId",
                principalTable: "RefTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_RefTerm_RefTermId",
                table: "Asset");

            migrationBuilder.DropIndex(
                name: "IX_Asset_RefTermId",
                table: "Asset");

            migrationBuilder.DeleteData(
                table: "RefSet",
                keyColumn: "Id",
                keyValue: new Guid("dc0dbb4a-fc40-40a6-a2c7-a9b7d721b572"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("16f0ae0e-0bda-4918-b8b2-ce8dddfb8c34"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("30b738e9-ae98-4f0b-9a7c-2d2eb75b2d81"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("4f0ad96f-69e1-4ac3-a235-f729b270fbe3"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("75ddb934-6483-40dc-b8f9-f2bae2b378de"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("7ac94584-fb91-4a4e-ba09-54490f2c1ddb"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("7d8f9798-7696-4d74-b86c-9a4ba9126c8f"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("826469ff-6e5f-4f04-b305-627b5e98120d"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("82ce80fa-fbc8-4d4c-9392-fcef56a55855"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("884f3f45-566a-4749-8513-ff133f109b7c"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("9359560b-df94-4936-b905-8be51cd6b492"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("9c1cdc55-6b41-4a07-b6f7-41d8fafef1cc"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("a88d7ccc-3358-488d-a962-b7cc545f1052"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("c8578ed2-83aa-40ff-82df-cbd415d53b93"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("c86fd1ee-15ef-45e1-8c1a-00179473c4b5"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("cac1a75c-0061-4e2d-a48b-1855cfc28bb3"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("d688b39c-b74b-480e-a244-3b9fef95e18a"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("e07891b8-1612-4d37-8f12-7ce78e0c6d71"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("e1c93602-8c17-4e4e-9fa5-b771ced61f42"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("e39c6b69-8afc-439b-a6a0-0c474cf0003f"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("ebbfb36d-2826-4d6e-bdf9-b1a7774cf484"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("f638f66f-28c1-4c2b-a014-bf6ffac25233"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("f8ebbf1c-f41c-48d9-87b0-86b70c7bbf73"));

            migrationBuilder.DropColumn(
                name: "RefTermId",
                table: "Asset");
        }
    }
}
