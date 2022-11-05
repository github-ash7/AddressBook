using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        //Creates table for User, Email, Address, Phone, RefTerm, RefSet, SetRefTerm
        public DbSet<User> User { get; set; }

        public DbSet<Email> Email { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Phone> Phone { get; set; }

        public DbSet<RefTerm> RefTerm { get; set; }

        public DbSet<RefSet> RefSet { get; set; }

        public DbSet<SetRefTerm> SetRefTerm { get; set; }

        public DbSet<Asset> Asset { get; set; }

        //The following lines of code seeds the tables, RefTerm, RefSet and SetRefTerm
        //The tables are seeded with the some predefined values as the metadata is a constant one and the user can only choose a value from this list
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RefSet>().HasData(
                new RefSet()
                {
                    Id = Guid.Parse("96388fb1-74c2-4915-88d0-c1a2d9b8600d"),
                    Key = "ADDRESS_TYPE"
                },
                new RefSet()
                {
                    Id = Guid.Parse("a929dfdc-207b-4578-85e9-20edf77e353f"),
                    Key = "PHONE_NUMBER_TYPE"
                },
                new RefSet()
                {
                    Id = Guid.Parse("f3adda1e-ee6b-41f8-9b26-d23d135b6893"),
                    Key = "EMAIL_ADDRESS_TYPE"
                },
                new RefSet()
                {
                    Id = Guid.Parse("dc0dbb4a-fc40-40a6-a2c7-a9b7d721b572"),
                    Key = "ASSET_TYPE"
                }
            );

            modelBuilder.Entity<RefTerm>().HasData(
                new RefTerm()
                {
                    Id = Guid.Parse("ad0cfe12-3b16-47ae-b9e2-c534bc57686d"),
                    Key = "PERSONAL",
                    Description = "RefTerm key for EMAIL_ADDRESS_TYPE, ADDRESS_TYPE and PHONE_NUMBER_TYPE"

                },
                new RefTerm()
                {
                    Id = Guid.Parse("1bb955a3-5fef-428a-a763-97eadb9e46ac"),
                    Key = "WORK",
                    Description = "RefTerm key for EMAIL_ADDRESS_TYPE, ADDRESS_TYPE and PHONE_NUMBER_TYPE"

                },
                new RefTerm()
                {
                    Id = Guid.Parse("aabe0ac9-35e4-45af-ab6f-48bcbe16eba1"),
                    Key = "ALTERNATE",
                    Description = "RefTerm key for PHONE_NUMBER_TYPE"

                },
                new RefTerm()
                {
                    Id = Guid.Parse("f638f66f-28c1-4c2b-a014-bf6ffac25233"),
                    Key = "apk",
                    Description = "RefTerm key for ASSET_TYPE - Android package file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("a88d7ccc-3358-488d-a962-b7cc545f1052"),
                    Key = "bin",
                    Description = "RefTerm key for ASSET_TYPE - Binary file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("ebbfb36d-2826-4d6e-bdf9-b1a7774cf484"),
                    Key = "exe",
                    Description = "RefTerm key for ASSET_TYPE - Executable file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("884f3f45-566a-4749-8513-ff133f109b7c"),
                    Key = "jar",
                    Description = "RefTerm key for ASSET_TYPE - Java Archive file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("e1c93602-8c17-4e4e-9fa5-b771ced61f42"),
                    Key = "py",
                    Description = "RefTerm key for ASSET_TYPE - Python file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("e07891b8-1612-4d37-8f12-7ce78e0c6d71"),
                    Key = "aif",
                    Description = "RefTerm key for ASSET_TYPE - Audio Interchange audio file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("e39c6b69-8afc-439b-a6a0-0c474cf0003f"),
                    Key = "cda",
                    Description = "RefTerm key for ASSET_TYPE - CD audio track file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("9359560b-df94-4936-b905-8be51cd6b492"),
                    Key = "mp3",
                    Description = "RefTerm key for ASSET_TYPE - MP3 audio file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("75ddb934-6483-40dc-b8f9-f2bae2b378de"),
                    Key = "wav",
                    Description = "RefTerm key for ASSET_TYPE - WAVE file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("30b738e9-ae98-4f0b-9a7c-2d2eb75b2d81"),
                    Key = "wma",
                    Description = "RefTerm key for ASSET_TYPE - Windows Media audio file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("16f0ae0e-0bda-4918-b8b2-ce8dddfb8c34"),
                    Key = "avi",
                    Description = "RefTerm key for ASSET_TYPE - Audio Video Interleave File"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("c86fd1ee-15ef-45e1-8c1a-00179473c4b5"),
                    Key = "mkv",
                    Description = "RefTerm key for ASSET_TYPE - Matroska Multimedia Container"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("f8ebbf1c-f41c-48d9-87b0-86b70c7bbf73"),
                    Key = "mov",
                    Description = "RefTerm key for ASSET_TYPE - Apple QuickTime movie File"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("d688b39c-b74b-480e-a244-3b9fef95e18a"),
                    Key = "mp4",
                    Description = "RefTerm key for ASSET_TYPE - MPEG-4 Video File"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("4f0ad96f-69e1-4ac3-a235-f729b270fbe3"),
                    Key = "wmv",
                    Description = "RefTerm key for ASSET_TYPE - Windows Media Video File"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("7d8f9798-7696-4d74-b86c-9a4ba9126c8f"),
                    Key = "doc",
                    Description = "RefTerm key for ASSET_TYPE - Microsoft Word file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("7ac94584-fb91-4a4e-ba09-54490f2c1ddb"),
                    Key = "docx",
                    Description = "RefTerm key for ASSET_TYPE - Microsoft Word file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("826469ff-6e5f-4f04-b305-627b5e98120d"),
                    Key = "pdf",
                    Description = "RefTerm key for ASSET_TYPE - PDF file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("9c1cdc55-6b41-4a07-b6f7-41d8fafef1cc"),
                    Key = "txt",
                    Description = "RefTerm key for ASSET_TYPE - Plain text file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("82ce80fa-fbc8-4d4c-9392-fcef56a55855"),
                    Key = "xlr",
                    Description = "RefTerm key for ASSET_TYPE - Microsoft Works spreadsheet file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("cac1a75c-0061-4e2d-a48b-1855cfc28bb3"),
                    Key = "xls",
                    Description = "RefTerm key for ASSET_TYPE - Microsoft Excel file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("c8578ed2-83aa-40ff-82df-cbd415d53b93"),
                    Key = "xlsx",
                    Description = "RefTerm key for ASSET_TYPE - Microsoft Excel Open XML spreadsheet file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("346d765e-bf64-40ed-9fa5-9de57a2e5cc9"),
                    Key = "ppt",
                    Description = "RefTerm key for ASSET_TYPE - PowerPoint presentation"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("bc79dbc7-1d12-4dde-bc23-29d56a6e7ba7"),
                    Key = "pptx",
                    Description = "RefTerm key for ASSET_TYPE - PowerPoint Open XML presentation"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("e460009d-515a-4328-a540-cf07e16169f1"),
                    Key = "csv",
                    Description = "RefTerm key for ASSET_TYPE - Comma separated value file"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("bf361cf4-5ace-4af3-b0a8-4c3aae1e9be3"),
                    Key = "gif",
                    Description = "RefTerm key for ASSET_TYPE - Graphical Interchange Format image"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("2cadf982-3566-46bb-b11d-bb39fbcc87f5"),
                    Key = "jpeg",
                    Description = "RefTerm key for ASSET_TYPE - JPEG image"
                },
                new RefTerm()
                {
                    Id = Guid.Parse("71cd4872-3568-4f94-a813-9d0e94bb85ca"),
                    Key = "png",
                    Description = "RefTerm key for ASSET_TYPE - Portable Network Graphic image"
                }
            );

            modelBuilder.Entity<SetRefTerm>().HasData(

                //ADDRESS_TYPE with PERSONAL
                new SetRefTerm()
                {
                    Id = Guid.Parse("c92f9237-d91b-4f00-9c79-4e3a9c3bdb26"),
                    RefSetId = Guid.Parse("96388fb1-74c2-4915-88d0-c1a2d9b8600d"),
                    RefTermId = Guid.Parse("ad0cfe12-3b16-47ae-b9e2-c534bc57686d")
                },

                //ADDRESS_TYPE with WORK
                new SetRefTerm()
                {
                    Id = Guid.Parse("163a753c-4ba3-4ef3-9e93-09071c715389"),
                    RefSetId = Guid.Parse("96388fb1-74c2-4915-88d0-c1a2d9b8600d"),
                    RefTermId = Guid.Parse("1bb955a3-5fef-428a-a763-97eadb9e46ac")
                },

                //PHONE_NUMBER_TYPE with PERSONAL
                new SetRefTerm()
                {
                    Id = Guid.Parse("633a4b3b-eefd-4d8c-9d32-47d3511ad89e"),
                    RefSetId = Guid.Parse("a929dfdc-207b-4578-85e9-20edf77e353f"),
                    RefTermId = Guid.Parse("ad0cfe12-3b16-47ae-b9e2-c534bc57686d")
                },

                //PHONE_NUMBER_TYPE with WORK
                new SetRefTerm()
                {
                    Id = Guid.Parse("ecdac221-1e9b-4a96-bf61-b1503ceb87eb"),
                    RefSetId = Guid.Parse("a929dfdc-207b-4578-85e9-20edf77e353f"),
                    RefTermId = Guid.Parse("1bb955a3-5fef-428a-a763-97eadb9e46ac")
                },

                //PHONE_NUMBER_TYPE with ALTERNATE
                new SetRefTerm()
                {
                    Id = Guid.Parse("789bf1c7-7e43-4f8b-bf2e-a3dd2397794b"),
                    RefSetId = Guid.Parse("a929dfdc-207b-4578-85e9-20edf77e353f"),
                    RefTermId = Guid.Parse("aabe0ac9-35e4-45af-ab6f-48bcbe16eba1")
                },

                //EMAIL_ADDRESS_TYPE with PERSONAL
                new SetRefTerm()
                {
                    Id = Guid.Parse("4fbd7121-54fa-4912-b977-6637867938a4"),
                    RefSetId = Guid.Parse("f3adda1e-ee6b-41f8-9b26-d23d135b6893"),
                    RefTermId = Guid.Parse("ad0cfe12-3b16-47ae-b9e2-c534bc57686d")
                },

                //EMAIL_ADDRESS_TYPE with WORK
                new SetRefTerm()
                {
                    Id = Guid.Parse("5e1d7a3b-4688-4f8d-8512-4878f214304f"),
                    RefSetId = Guid.Parse("f3adda1e-ee6b-41f8-9b26-d23d135b6893"),
                    RefTermId = Guid.Parse("1bb955a3-5fef-428a-a763-97eadb9e46ac")
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
