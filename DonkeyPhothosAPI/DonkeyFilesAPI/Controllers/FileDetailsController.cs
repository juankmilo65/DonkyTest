using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DonkeyFilesBL.Files;
using DonkeyFilesBL.Interfaces;
using DonkeyFilesDML.DTO;
using Microsoft.EntityFrameworkCore;

namespace DonkeyFilesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileDetailsController : ControllerBase
    {
        private readonly IFilesDetailsBll _filesDetailsBll;

        public FileDetailsController(FilesDetailsBll filesDetailsBll)
        {
            _filesDetailsBll = filesDetailsBll;
        }

        // GET: api/FileDetails
        [HttpGet]
        public async Task<IEnumerable<FillesDetailsDTO>> GetFileDetails()
        {
            return await _filesDetailsBll.GetFileDetails();
        }

        // GET: api/FileDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FillesDetailsDTO>> GetFileDetails(int id)
        {
            var fileDetails = await _filesDetailsBll.GetFileDetails(id);

            if (fileDetails == null)
            {
                return NotFound();
            }

            return fileDetails;
        }

        // PUT: api/FileDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<FillesDetailsDTO>> PutFileDetails(int id, FillesDetailsDTO fileDetails)
        {
            if (id != fileDetails.FileId)
            {
                return BadRequest();
            }

            try
            {
                return await _filesDetailsBll.PutFileDetails(id, fileDetails);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _filesDetailsBll.FileDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FileDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FillesDetailsDTO>> PostFileDetails(FillesDetailsDTO fileDetails)
        {
            return await _filesDetailsBll.PostFileDetails(fileDetails);
        }

        // DELETE: api/FileDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFileDetails(int id)
        {
            var result = await _filesDetailsBll.DeleteFileDetails(id);

            if (result)
            {
                return NoContent();

            }
            return NotFound();

        }

    }
}
