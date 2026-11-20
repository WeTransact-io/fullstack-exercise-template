using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Api.Tests;

// Proves the app starts. Add your own tests next to this file.
public class SmokeTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task App_starts()
    {
        var response = await factory.CreateClient().GetAsync("/health");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
