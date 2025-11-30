using Microsoft.AspNetCore.Builder;

namespace CSharpSandbox;

public class Program
{
    private static readonly Dictionary<string, string> BigDict = new();

    static async Task<string> RootGetHandler()
    {
        for (int i = 0; i < 1_000_000; i++)
        {
            BigDict.Add(i.ToString(), i.ToString());
        }

        return await Task.FromResult($"Memory usage grows >:) Dict size is: {BigDict.Count}");
    }

    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        app.MapGet("/api/consume_memory", RootGetHandler);
        app.Run();
    }
}