using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CSharpSandbox.Test;

public class ProgramTest
{
    [Fact]
    public async Task Returns_200()
    {
        var app = new WebApplicationFactory<Program>();
        var client = app.CreateClient();

        var response = await client.GetAsync("/api/consume_memory");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}