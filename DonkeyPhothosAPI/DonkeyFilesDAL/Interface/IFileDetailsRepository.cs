using DonkeyFilesDAL.Models;
using DonkeyFilesDML.DTO;
using System.Collections.Generic;

namespace DonkeyFilesDAL.Interface
{
    public interface IFileDetailsRepository
    {
        IEnumerable<FileDetailsModel> GetFileDetails();
        FileDetailsModel GetFileDetails(int id);
        FileDetailsModel PostFileDetails(FileDetailsModel fileDetails);
        FileDetailsModel PutFileDetails(int id, FileDetailsModel fileDetails);
        bool FileDetailsExists(int id);
        bool DeleteFileDetails(int id);
    }
}
