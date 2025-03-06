using CalendarAPI.DB;
using CalendarAPI.Service;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.Data.Sqlite;
using Scalar.AspNetCore;

using var keepAliveConnection = new SqliteConnection(CalendarContext.ConnectionString);
keepAliveConnection.Open();
CalendarContext.Seed();

var bld = WebApplication.CreateBuilder();
bld.Services.AddCors(options =>
        options.AddPolicy(name: "AllowAllOrigins",
        configurePolicy: policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        }))
    .AddFastEndpoints()
    .SwaggerDocument()
    .AddDbContext<CalendarContext>()
    .AddScoped<ICalendarService, CalendarService>();

var app = bld.Build();
app.UseCors("AllowAllOrigins");
app.UseFastEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi(c => c.Path = "/openapi/{documentName}.json");
    app.MapScalarApiReference();
}

app.Run();

public partial class Program;
