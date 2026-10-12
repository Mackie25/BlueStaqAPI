using BluestaqAPI.BusinessLogic;
using BluestaqAPI.Interfaces;
using BluestaqAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BluestaqAPI.Controllers
{
    [ApiController]
    [Route("notes")]
    public class NotesController : ControllerBase
    {
        private readonly INotesLogic _notesLogic;

        public NotesController(INotesLogic notesLogic)
        {
            _notesLogic = notesLogic;
        }

        [HttpPost]
        [Route("RegisterNewNote")]
        public async Task<IActionResult> RegisterNewNote([FromBody] string note, string userId)
        {
            //Check good note with user id and make sure the note is not empty
            if (string.IsNullOrEmpty(note))
            {
                return BadRequest("Note cannot be empty.");
            }
            else if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID cannot be empty.");
            }
            else
            {
                //Send the note to be registered in the database

                var newNote = new Notes()
                {
                    Note = note,
                    UserId = int.Parse(userId),
                    Active = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                var success = await _notesLogic.RegisterNewNote(newNote);
            }

            return Ok("Note registered successfully.");
        }

        [HttpGet]
        [Route("GetAllNotes")]
        public async Task<IActionResult> GetAllNotes()
        {
            var notes = await _notesLogic.GetAllNotes();

            return Ok(notes);
        }

        [HttpGet]
        [Route("GetAllNotesByUserId/{id}")]
        public async Task<IActionResult> GetAllNotesByUserId(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest("User ID cannot be empty.");
            }

            var notes = await _notesLogic.GetAllNotesByUserId(id);

            if (notes == null)
            {
                return NotFound("Note(s)s not found.");
            }

            return Ok(notes);
        }

        [HttpPut]
        [Route("UpdateNote")]
        public async Task<IActionResult> UpdateNote([FromBody] Notes note)
        {
            //Check good note with user id and make sure the note is not empty

            int noteId = 0;

            if (note == null || string.IsNullOrEmpty(note.Note))
            {
                return BadRequest("Note cannot be empty.");
            }
            else if (note.UserId == null)
            {
                return BadRequest("User ID cannot be empty.");
            }
            else
            {
                //Send the note to be updated in the database
                noteId = await _notesLogic.UpdateNote(note);

                if(noteId == -1)
                {
                    return NotFound("Note not found.");
                }
            }

            return Ok($"Note updated successfully. The Id is = {noteId}");
        }
    }
}
