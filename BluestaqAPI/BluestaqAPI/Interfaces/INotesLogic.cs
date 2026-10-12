using BluestaqAPI.Models;

namespace BluestaqAPI.Interfaces
{
    public interface INotesLogic
    {
        Task<int> RegisterNewNote(Notes note);

        Task<List<Notes>> GetAllNotes();

        Task<List<Notes>> GetAllNotesByUserId(int userId);

        Task<int> UpdateNote(Notes note);
    }
}
