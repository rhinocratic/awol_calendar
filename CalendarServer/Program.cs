using CalendarServer.Data;
using CalendarServer.Model.Entity;
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
    ID = new Guid(),
    Interval = new DateTimeRange(DateTime.UtcNow, DateTime.UtcNow.Add(TimeSpan.FromHours(1)))
});

dbContext.Add(new Event
{
    Name = "Event Two",
    Description = "Second Event",
    ID = new Guid(),
    Interval = new DateTimeRange(DateTime.UtcNow.Add(TimeSpan.FromHours(2)), DateTime.UtcNow.Add(TimeSpan.FromHours(3)))
});

dbContext.SaveChanges();

foreach (var evt in dbContext.Events)
{
    Console.WriteLine(evt.ToString());
}



var bld = WebApplication.CreateBuilder();
bld.Services.AddFastEndpoints();

var app = bld.Build();
app.UseFastEndpoints();
app.Run();

