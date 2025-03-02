using CalendarAPI.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace CalendarAPI.DB;

public class CalendarContext : DbContext{

    public const string ConnectionString = "DataSource=awolcalendar;mode=memory;cache=shared";

    public DbSet<Event> Events {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite(ConnectionString);

}