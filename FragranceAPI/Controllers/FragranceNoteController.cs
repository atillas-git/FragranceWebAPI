using Application.Dtos.FragranceNote;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FragranceAPI.Controllers
{
    [Route("api/fragranceNote")]
    public class FragranceNoteController : Controller
    {
        private readonly IFragranceNoteService _fagranceNoteService;

        public FragranceNoteController(IFragranceNoteService fragranceNoteService)
        {
            _fagranceNoteService = fragranceNoteService;
        }

        [HttpGet("admin")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllFragranceNotesAsync()
        {
            var fragranceNotes = await _fagranceNoteService.GetAllFragranceNotesAsync();
            return Ok(fragranceNotes);
        }
        [HttpPost("admin")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddFragranceNoteAsync(FragranceNoteCreateUpdateDto fragranceNoteCreateUpdateDto)
        {
            await _fagranceNoteService.AddFragranceNoteAsync(fragranceNoteCreateUpdateDto);
            return Ok();
        }
        [HttpPut("admin/{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateFragranceAsync(int id,FragranceNoteCreateUpdateDto fragranceNoteCreateUpdateDto)
        {
            await _fagranceNoteService.UpdateFragranceNoteAsync(id,fragranceNoteCreateUpdateDto);
            return Ok();
        }
        [HttpDelete("admin/{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteFragranceNoteAsync(int id)
        {
            await _fagranceNoteService.DeleteFragranceNoteAsync(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFragranceNoteAsync(int id)
        {
            var fragranceNote = await _fagranceNoteService.GetFragranceNoteByIdAsync(id);
            return Ok(fragranceNote);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchFragranceNotes(string query = "",int pageNumber = 1,int pageSize = 10)
        {
            var fragranceNotes = await _fagranceNoteService.SearchFragranceNotesAsync(query,pageNumber,pageSize);
            return Ok(fragranceNotes);
        }
    }
}
