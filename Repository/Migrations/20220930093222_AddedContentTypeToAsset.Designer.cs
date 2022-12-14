// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220930093222_AddedContentTypeToAsset")]
    partial class AddedContentTypeToAsset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RefTermId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StateName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RefTermId");

                    b.HasIndex("UserId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Entities.Models.Asset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Content")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RefTermId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RefTermId");

                    b.HasIndex("UserId");

                    b.ToTable("Asset");
                });

            modelBuilder.Entity("Entities.Models.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RefTermId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RefTermId");

                    b.HasIndex("UserId");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("Entities.Models.Phone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.Property<Guid>("RefTermId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RefTermId");

                    b.HasIndex("UserId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("Entities.Models.RefSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RefSet");

                    b.HasData(
                        new
                        {
                            Id = new Guid("96388fb1-74c2-4915-88d0-c1a2d9b8600d"),
                            Key = "ADDRESS_TYPE"
                        },
                        new
                        {
                            Id = new Guid("a929dfdc-207b-4578-85e9-20edf77e353f"),
                            Key = "PHONE_NUMBER_TYPE"
                        },
                        new
                        {
                            Id = new Guid("f3adda1e-ee6b-41f8-9b26-d23d135b6893"),
                            Key = "EMAIL_ADDRESS_TYPE"
                        },
                        new
                        {
                            Id = new Guid("dc0dbb4a-fc40-40a6-a2c7-a9b7d721b572"),
                            Key = "ASSET_TYPE"
                        });
                });

            modelBuilder.Entity("Entities.Models.RefTerm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RefTerm");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ad0cfe12-3b16-47ae-b9e2-c534bc57686d"),
                            Description = "RefTerm key for EMAIL_ADDRESS_TYPE, ADDRESS_TYPE and PHONE_NUMBER_TYPE",
                            Key = "PERSONAL"
                        },
                        new
                        {
                            Id = new Guid("1bb955a3-5fef-428a-a763-97eadb9e46ac"),
                            Description = "RefTerm key for EMAIL_ADDRESS_TYPE, ADDRESS_TYPE and PHONE_NUMBER_TYPE",
                            Key = "WORK"
                        },
                        new
                        {
                            Id = new Guid("aabe0ac9-35e4-45af-ab6f-48bcbe16eba1"),
                            Description = "RefTerm key for PHONE_NUMBER_TYPE",
                            Key = "ALTERNATE"
                        },
                        new
                        {
                            Id = new Guid("f638f66f-28c1-4c2b-a014-bf6ffac25233"),
                            Description = "RefTerm key for ASSET_TYPE - Android package file",
                            Key = "apk"
                        },
                        new
                        {
                            Id = new Guid("a88d7ccc-3358-488d-a962-b7cc545f1052"),
                            Description = "RefTerm key for ASSET_TYPE - Binary file",
                            Key = "bin"
                        },
                        new
                        {
                            Id = new Guid("ebbfb36d-2826-4d6e-bdf9-b1a7774cf484"),
                            Description = "RefTerm key for ASSET_TYPE - Executable file",
                            Key = "exe"
                        },
                        new
                        {
                            Id = new Guid("884f3f45-566a-4749-8513-ff133f109b7c"),
                            Description = "RefTerm key for ASSET_TYPE - Java Archive file",
                            Key = "jar"
                        },
                        new
                        {
                            Id = new Guid("e1c93602-8c17-4e4e-9fa5-b771ced61f42"),
                            Description = "RefTerm key for ASSET_TYPE - Python file",
                            Key = "py"
                        },
                        new
                        {
                            Id = new Guid("e07891b8-1612-4d37-8f12-7ce78e0c6d71"),
                            Description = "RefTerm key for ASSET_TYPE - Audio Interchange audio file",
                            Key = "aif"
                        },
                        new
                        {
                            Id = new Guid("e39c6b69-8afc-439b-a6a0-0c474cf0003f"),
                            Description = "RefTerm key for ASSET_TYPE - CD audio track file",
                            Key = "cda"
                        },
                        new
                        {
                            Id = new Guid("9359560b-df94-4936-b905-8be51cd6b492"),
                            Description = "RefTerm key for ASSET_TYPE - MP3 audio file",
                            Key = "mp3"
                        },
                        new
                        {
                            Id = new Guid("75ddb934-6483-40dc-b8f9-f2bae2b378de"),
                            Description = "RefTerm key for ASSET_TYPE - WAVE file",
                            Key = "wav"
                        },
                        new
                        {
                            Id = new Guid("30b738e9-ae98-4f0b-9a7c-2d2eb75b2d81"),
                            Description = "RefTerm key for ASSET_TYPE - Windows Media audio file",
                            Key = "wma"
                        },
                        new
                        {
                            Id = new Guid("16f0ae0e-0bda-4918-b8b2-ce8dddfb8c34"),
                            Description = "RefTerm key for ASSET_TYPE - Audio Video Interleave File",
                            Key = "avi"
                        },
                        new
                        {
                            Id = new Guid("c86fd1ee-15ef-45e1-8c1a-00179473c4b5"),
                            Description = "RefTerm key for ASSET_TYPE - Matroska Multimedia Container",
                            Key = "mkv"
                        },
                        new
                        {
                            Id = new Guid("f8ebbf1c-f41c-48d9-87b0-86b70c7bbf73"),
                            Description = "RefTerm key for ASSET_TYPE - Apple QuickTime movie File",
                            Key = "mov"
                        },
                        new
                        {
                            Id = new Guid("d688b39c-b74b-480e-a244-3b9fef95e18a"),
                            Description = "RefTerm key for ASSET_TYPE - MPEG-4 Video File",
                            Key = "mp4"
                        },
                        new
                        {
                            Id = new Guid("4f0ad96f-69e1-4ac3-a235-f729b270fbe3"),
                            Description = "RefTerm key for ASSET_TYPE - Windows Media Video File",
                            Key = "wmv"
                        },
                        new
                        {
                            Id = new Guid("7d8f9798-7696-4d74-b86c-9a4ba9126c8f"),
                            Description = "RefTerm key for ASSET_TYPE - Microsoft Word file",
                            Key = "doc"
                        },
                        new
                        {
                            Id = new Guid("7ac94584-fb91-4a4e-ba09-54490f2c1ddb"),
                            Description = "RefTerm key for ASSET_TYPE - Microsoft Word file",
                            Key = "docx"
                        },
                        new
                        {
                            Id = new Guid("826469ff-6e5f-4f04-b305-627b5e98120d"),
                            Description = "RefTerm key for ASSET_TYPE - PDF file",
                            Key = "pdf"
                        },
                        new
                        {
                            Id = new Guid("9c1cdc55-6b41-4a07-b6f7-41d8fafef1cc"),
                            Description = "RefTerm key for ASSET_TYPE - Plain text file",
                            Key = "txt"
                        },
                        new
                        {
                            Id = new Guid("82ce80fa-fbc8-4d4c-9392-fcef56a55855"),
                            Description = "RefTerm key for ASSET_TYPE - Microsoft Works spreadsheet file",
                            Key = "xlr"
                        },
                        new
                        {
                            Id = new Guid("cac1a75c-0061-4e2d-a48b-1855cfc28bb3"),
                            Description = "RefTerm key for ASSET_TYPE - Microsoft Excel file",
                            Key = "xls"
                        },
                        new
                        {
                            Id = new Guid("c8578ed2-83aa-40ff-82df-cbd415d53b93"),
                            Description = "RefTerm key for ASSET_TYPE - Microsoft Excel Open XML spreadsheet file",
                            Key = "xlsx"
                        },
                        new
                        {
                            Id = new Guid("346d765e-bf64-40ed-9fa5-9de57a2e5cc9"),
                            Description = "RefTerm key for ASSET_TYPE - PowerPoint presentation",
                            Key = "ppt"
                        },
                        new
                        {
                            Id = new Guid("bc79dbc7-1d12-4dde-bc23-29d56a6e7ba7"),
                            Description = "RefTerm key for ASSET_TYPE - PowerPoint Open XML presentation",
                            Key = "pptx"
                        },
                        new
                        {
                            Id = new Guid("e460009d-515a-4328-a540-cf07e16169f1"),
                            Description = "RefTerm key for ASSET_TYPE - Comma separated value file",
                            Key = "csv"
                        },
                        new
                        {
                            Id = new Guid("bf361cf4-5ace-4af3-b0a8-4c3aae1e9be3"),
                            Description = "RefTerm key for ASSET_TYPE - Graphical Interchange Format image",
                            Key = "gif"
                        },
                        new
                        {
                            Id = new Guid("2cadf982-3566-46bb-b11d-bb39fbcc87f5"),
                            Description = "RefTerm key for ASSET_TYPE - JPEG image",
                            Key = "jpeg"
                        },
                        new
                        {
                            Id = new Guid("71cd4872-3568-4f94-a813-9d0e94bb85ca"),
                            Description = "RefTerm key for ASSET_TYPE - Portable Network Graphic image",
                            Key = "png"
                        });
                });

            modelBuilder.Entity("Entities.Models.SetRefTerm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RefSetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RefTermId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RefSetId");

                    b.HasIndex("RefTermId");

                    b.ToTable("SetRefTerm");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c92f9237-d91b-4f00-9c79-4e3a9c3bdb26"),
                            RefSetId = new Guid("96388fb1-74c2-4915-88d0-c1a2d9b8600d"),
                            RefTermId = new Guid("ad0cfe12-3b16-47ae-b9e2-c534bc57686d")
                        },
                        new
                        {
                            Id = new Guid("163a753c-4ba3-4ef3-9e93-09071c715389"),
                            RefSetId = new Guid("96388fb1-74c2-4915-88d0-c1a2d9b8600d"),
                            RefTermId = new Guid("1bb955a3-5fef-428a-a763-97eadb9e46ac")
                        },
                        new
                        {
                            Id = new Guid("633a4b3b-eefd-4d8c-9d32-47d3511ad89e"),
                            RefSetId = new Guid("a929dfdc-207b-4578-85e9-20edf77e353f"),
                            RefTermId = new Guid("ad0cfe12-3b16-47ae-b9e2-c534bc57686d")
                        },
                        new
                        {
                            Id = new Guid("ecdac221-1e9b-4a96-bf61-b1503ceb87eb"),
                            RefSetId = new Guid("a929dfdc-207b-4578-85e9-20edf77e353f"),
                            RefTermId = new Guid("1bb955a3-5fef-428a-a763-97eadb9e46ac")
                        },
                        new
                        {
                            Id = new Guid("789bf1c7-7e43-4f8b-bf2e-a3dd2397794b"),
                            RefSetId = new Guid("a929dfdc-207b-4578-85e9-20edf77e353f"),
                            RefTermId = new Guid("aabe0ac9-35e4-45af-ab6f-48bcbe16eba1")
                        },
                        new
                        {
                            Id = new Guid("4fbd7121-54fa-4912-b977-6637867938a4"),
                            RefSetId = new Guid("f3adda1e-ee6b-41f8-9b26-d23d135b6893"),
                            RefTermId = new Guid("ad0cfe12-3b16-47ae-b9e2-c534bc57686d")
                        },
                        new
                        {
                            Id = new Guid("5e1d7a3b-4688-4f8d-8512-4878f214304f"),
                            RefSetId = new Guid("f3adda1e-ee6b-41f8-9b26-d23d135b6893"),
                            RefTermId = new Guid("1bb955a3-5fef-428a-a763-97eadb9e46ac")
                        });
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Entities.Models.Address", b =>
                {
                    b.HasOne("Entities.Models.RefTerm", "RefTerm")
                        .WithMany()
                        .HasForeignKey("RefTermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RefTerm");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.Asset", b =>
                {
                    b.HasOne("Entities.Models.RefTerm", "RefTerm")
                        .WithMany()
                        .HasForeignKey("RefTermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RefTerm");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.Email", b =>
                {
                    b.HasOne("Entities.Models.RefTerm", "RefTerm")
                        .WithMany()
                        .HasForeignKey("RefTermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("Emails")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RefTerm");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.Phone", b =>
                {
                    b.HasOne("Entities.Models.RefTerm", "RefTerm")
                        .WithMany()
                        .HasForeignKey("RefTermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("Phones")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RefTerm");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.SetRefTerm", b =>
                {
                    b.HasOne("Entities.Models.RefSet", "RefSet")
                        .WithMany()
                        .HasForeignKey("RefSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.RefTerm", "RefTerm")
                        .WithMany()
                        .HasForeignKey("RefTermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RefSet");

                    b.Navigation("RefTerm");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Emails");

                    b.Navigation("Phones");
                });
#pragma warning restore 612, 618
        }
    }
}
