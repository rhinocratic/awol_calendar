using CalendarAPI.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace CalendarAPI.DB;

public class CalendarContext : DbContext
{
    public const string ConnectionString = "DataSource=awolcalendar;mode=memory;cache=shared";

    public DbSet<Event> Events { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite(ConnectionString);

    public static void Seed()
    {
        using var dbContext = new CalendarContext();
        if (!dbContext.Database.EnsureCreated())
        {
            return;
        }

        dbContext.Add(new Event
        {
            Title = "Event One",
            Location = "Meeting Room 1",
            Interval = new DateTimeRange(DateTime.UtcNow, DateTime.UtcNow.Add(TimeSpan.FromHours(1)))
        });

        dbContext.Add(new Event
        {
            Title = "Event Two",
            Location = "Meeting Room 2",
            Interval = new DateTimeRange(DateTime.UtcNow.Add(TimeSpan.FromHours(2)), DateTime.UtcNow.Add(TimeSpan.FromHours(3)))
        });

        dbContext.SaveChanges();

        foreach (var evt in dbContext.Events)
        {
            Console.WriteLine($"Event {evt.Title} has ID {evt.ID}");
        }
    }
}