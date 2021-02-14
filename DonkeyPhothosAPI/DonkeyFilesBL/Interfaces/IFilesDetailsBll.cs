using DonkeyFilesDML.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeyFilesBL.Interfaces
{
    public interface IFilesDetailsBll
    {
        Task<IEnumerable<FillesDetailsDTO>> GetFileDetails();
        Task<FillesDetailsDTO> GetFileDetails(int id);
        Task<FillesDetailsDTO> PostFileDetails(FillesDetailsDTO fileDetailsInput);
        Task<FillesDetailsDTO> PutFileDetails(int id, FillesDetailsDTO fileDetailsInput);
        Task<bool> FileDetailsExists(int id);
        Task<bool> DeleteFileDetails(int id);
    }
}
