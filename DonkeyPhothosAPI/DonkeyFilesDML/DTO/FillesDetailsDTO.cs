using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonkeyFilesDML.DTO
{
    public class FillesDetailsDTO
    {
        public int FileId { get; set; }
        public string FileName { get; set; }

        public string FileSize { get; set; }

        public string FileDate { get; set; }
    }
}
