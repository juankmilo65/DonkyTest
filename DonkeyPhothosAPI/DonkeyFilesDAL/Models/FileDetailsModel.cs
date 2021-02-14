using System;
using System.ComponentModel.DataAnnotations;

namespace DonkeyFilesDAL.Models
{
    public class FileDetailsModel
    {
        [Key]
        public int FileId { get; set; }
        public string FileName { get; set; }

        public string FileSize { get; set; }

        public string FileDate { get; set; }
    }
}
