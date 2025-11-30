using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CSharpSandbox.Test;

public class ProgramTest
{
    private readonly HttpClient _client;

    public ProgramTest()
    {
        var app = new WebApplicationFactory<Program>();
        _client = app.CreateClient();
    }

    [Fact]
    public async Task Responds_200_with_message()
    {
        var response = await _client.GetAsync("/api/consume_memory");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        (await response.Content.ReadAsStringAsync()).Should().Contain("Dict size is:");
    }

    [Fact]
    public async Task Responds_after_multiple_requests()
    {
        for (int i = 0; i < 10; i++)
        {
            var response = await _client.GetAsync("/api/consume_memory");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsStringAsync()).Should().Contain("Dict size is:");
        }
    }
}