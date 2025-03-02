using CalendarAPI.DB;
using CalendarAPI.Model.Entity;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;

using var keepAliveConnection = new SqliteConnection(CalendarContext.ConnectionString);
keepAliveConnection.Open();

using var dbContext = new CalendarContext();
dbContext.Database.EnsureCreated();

dbContext.Add(new Event
{
    Name = "Event One",
    Description = "First Event",
    Interval = new DateTimeRange(DateTime.UtcNow, DateTime.UtcNow.Add(TimeSpan.FromHours(1)))
});

dbContext.Add(new Event
{
    Name = "Event Two",
    Description = "Second Event",
    Interval = new DateTimeRange(DateTime.UtcNow.Add(TimeSpan.FromHours(2)), DateTime.UtcNow.Add(TimeSpan.FromHours(3)))
});

dbContext.SaveChanges();

foreach (var evt in dbContext.Events)
{
    Console.WriteLine($"Event {evt.Name} has ID {evt.ID}");
}



var bld = WebApplication.CreateBuilder();
bld.Services.AddFastEndpoints();

var app = bld.Build();
app.UseFastEndpoints();
app.Run();
