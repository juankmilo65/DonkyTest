using DonkeyFilesDAL.Context;
using DonkeyFilesDAL.Interface;
using DonkeyFilesDAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DonkeyFilesDAL.Repository
{
    public class FileDetailsRepository : IFileDetailsRepository
    {
        private readonly FilesContext _context;

        public FileDetailsRepository(FilesContext context)
        {
            _context = context;
        }

        public IEnumerable<FileDetailsModel> GetFileDetails()
        {
            return _context.FileDetails;
        }

        public FileDetailsModel GetFileDetails(int id)
        {
            var fileDetails = _context.FileDetails.Find(id);
            return fileDetails;
        }

        public FileDetailsModel PostFileDetails(FileDetailsModel fileDetails)
        {
            _context.FileDetails.Add(fileDetails);
            _context.SaveChanges();
            return GetFileDetails(fileDetails.FileId);
        }

        public FileDetailsModel PutFileDetails(int id, FileDetailsModel fileDetails)
        {

            _context.Entry(fileDetails).State = EntityState.Modified;
            _context.SaveChanges();
            return GetFileDetails(fileDetails.FileId);
        }

        public bool FileDetailsExists(int id)
        {
            return _context.FileDetails.Any(e => e.FileId == id);
        }

        public bool DeleteFileDetails(int id)
        {
            var fileDetails = _context.FileDetails.Find(id);
            if (fileDetails == null)
            {
                return false;
            }

            _context.FileDetails.Remove(fileDetails);
            _context.SaveChanges();

            return true;
        }
    }
}
