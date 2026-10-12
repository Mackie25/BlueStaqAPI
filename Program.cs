

using BluestaqAPI.BusinessLogic;
using BluestaqAPI.Interfaces;
using BluestaqAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddScoped<INotesLogic, NotesLogic>();

var notesList = new List<Notes>
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
builder.Services.AddSingleton(notesList);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "My API v1");
});

app.Run();
