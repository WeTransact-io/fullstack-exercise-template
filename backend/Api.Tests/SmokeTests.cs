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

    [Fact]
    public async Task Api_without_tenant_header_is_401()
    {
        var response = await factory.CreateClient().GetAsync("/api/anything");
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Api_with_tenant_header_gets_past_sign_in()
    {
        var client = factory.CreateClient();
        client.DefaultRequestHeaders.Add("X-Tenant-Id", Guid.NewGuid().ToString());
        var response = await client.GetAsync("/api/anything");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode); // no such route yet, but not 401
    }
}
