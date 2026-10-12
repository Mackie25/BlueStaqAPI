# BlueStaqAPI
Small API for registering new notes and editing the content of existing notes
After compiling th user can use the swagger this can be accessed using the http://localhost:<port>/swagger/index.html
Or use Portman to access the end points

current endpoints are 
Task<int> RegisterNewNote(Notes note);

Task<List<Notes>> GetAllNotes();

Task<List<Notes>> GetAllNotesByUserId(int userId);

Task<int> UpdateNote(Notes note);

A unit test project is also added to test the logic for each endpoint

