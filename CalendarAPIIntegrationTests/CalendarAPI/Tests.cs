using System.Formats.Asn1;
using CalendarAPI.Model;
using CalendarAPIIntegrationTests.CalendarAPI;

namespace CalendarAPIIntegrationTests.CalendarAPI;

public class Tests(App app) : TestBase<App>
{
    [Fact]
    public async Task InvalidUserInput()
    {
        var rsp = await app.Client.GetAsync("api/events/2025/01/04", TestContext.Current.CancellationToken);
        Console.WriteLine(rsp);
    }
}