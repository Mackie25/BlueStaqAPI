using BluestaqAPI;
using BluestaqAPI.BusinessLogic;
using BluestaqAPI.Interfaces;
using BluestaqAPI.Models;

namespace BlueStaqUnitTests
{
    public class UnitTest1
    {
        //This usint test goes directelly in and test the logic for the calls

        //Setup

        NotesLogic _testNotesLogic = new NotesLogic(new List<Notes>());

        //Crete a fake database with populated data to test the logic

        List <Notes> notesList = new List<Notes>
        {
            new Notes
            {
                Id = 1,
                Note = "First note for API demonstration",
                UserId = 1001,
                Active = true,
                CreatedAt = DateTime.Now.AddDays(-10),
                UpdatedAt = DateTime.Now.AddDays(-5)
            },
            new Notes
            {
                Id = 2,
                Note = "Second note example",
                UserId = 1002,
                Active = true,
                CreatedAt = DateTime.Now.AddDays(-7),
                UpdatedAt = DateTime.Now.AddDays(-2)
            },
            new Notes
            {
                Id = 3,
                Note = "Inactive note entry",
                UserId = 1003,
                Active = false,
                CreatedAt = DateTime.Now.AddDays(-20),
                UpdatedAt = DateTime.Now.AddDays(-15)
            }
        };

        [Fact]
        public void TestGetAllNotes()
        {
            var _testNotesLogic = new NotesLogic(notesList);

            var result = _testNotesLogic.GetAllNotes().Result;

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void TestGetAllNotesByUserId()
        {
            var _testNotesLogic = new NotesLogic(notesList);

            var result = _testNotesLogic.GetAllNotesByUserId(1001).Result;

            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void TestRegisterNewNote()
        {
            var _testNotesLogic = new NotesLogic(notesList);
            var newNote = new Notes
            {
                Id = 4,
                Note = "New note for testing",
                UserId = 1004,
                Active = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            var result = _testNotesLogic.RegisterNewNote(newNote).Result;
            Assert.Equal(4, result);
        }

        [Fact]
        public void TestUpdateNote()
        {
            var _testNotesLogic = new NotesLogic(notesList);
            var updatedNote = new Notes
            {
                Id = 1,
                Note = "Updated note for testing",
                UserId = 1001,
                Active = true,
                CreatedAt = DateTime.Now.AddDays(-10),
                UpdatedAt = DateTime.Now
            };
            var result = _testNotesLogic.UpdateNote(updatedNote).Result;
            Assert.Equal(1, result);
        }
    }
}
