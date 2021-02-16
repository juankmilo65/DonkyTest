using DonkeyFilesDAL.Context;
using DonkeyFilesDAL.Interface;
using DonkeyFilesDAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeyFilesTest
{
   public class TestHelper
    {
        private readonly FilesContext fileContext;
        public TestHelper()
        {
            var builder = new DbContextOptionsBuilder<FilesContext>();
            builder.UseInMemoryDatabase(databaseName: "LibraryDbInMemory");

            var dbContextOptions = builder.Options;
            fileContext = new FilesContext(dbContextOptions);
            // Delete existing db before creating a new one
            fileContext.Database.EnsureDeleted();
            fileContext.Database.EnsureCreated();
        }

        public IFileDetailsRepository GetInMemoryReadRepository()
        {
            return new FileDetailsRepository(fileContext);
        }
    }
}
