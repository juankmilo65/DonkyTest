using DonkeyFilesDAL.Models;
using Microsoft.EntityFrameworkCore;


namespace DonkeyFilesDAL.Context
{
    public class FilesContext:DbContext
    {
        public FilesContext(DbContextOptions options):base(options)
        {
                
        }

        public DbSet<FileDetailsModel> FileDetails { get; set; }
    }
}
