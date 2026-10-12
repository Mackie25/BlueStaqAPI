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

I first setup a project to see that endpoints I think I needed.

Then created them and thought about what models would be good for this project
This project can be used to link this design to any table for any database in the future so having a userId who created it and date created and modified is great to have.
I added in Active bool to make sure nothing is deleted as it can just be set to inactive if no longer needed.



