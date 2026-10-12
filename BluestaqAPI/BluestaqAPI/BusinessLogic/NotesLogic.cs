using BluestaqAPI.Interfaces;
using BluestaqAPI.Models;

namespace BluestaqAPI.BusinessLogic
{

    public class NotesLogic : INotesLogic
    {
        List<Notes> _notes = new List<Notes>();

        public NotesLogic(List<Notes> notesList)
        {
            //Constructor
            _notes = notesList;
        }

        public async Task<int> RegisterNewNote(Notes note)
        {
            //Save in Database
            var index = _notes.FindIndex(n => n.Id == note.Id);

            if (index != -1)
            {
                _notes[index] = note;
            }
            else
            {
                _notes.Add(note);
            }

            return note.Id;
        }

        public async Task<List<Notes>> GetAllNotes()
        {
            //Get the pre populated list here

            var notes = _notes;

            return notes;
        }

        public async Task<List<Notes>> GetAllNotesByUserId(int userId)
        {
            //Get all notes from database by user id

            var notes = _notes.Where(n => n.UserId == userId).ToList();

            return notes;
        }

        public async Task<int> UpdateNote(Notes note)
        {
            //Get the note based on the Id for the note and the user

            var noteSaved = _notes.FirstOrDefault(n => n.Id == note.Id && n.UserId == note.UserId);

            if(noteSaved == null)
            {
                return -1;
            }
            else
            {
                noteSaved.Note = note.Note;
                noteSaved.UpdatedAt = DateTime.Now;
            }

            return note.Id;
        }

    }
}
