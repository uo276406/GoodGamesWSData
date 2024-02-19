using GoodGames.Security;

internal class Program
{
    private static void Main(string[] args)
    {
        var host = new WebHostBuilder()
        .UseKestrel(x => x.AllowSynchronousIO = true)
        .UseUrls("http://*:9080")
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseStartup<Startup>()
        .ConfigureLogging(x =>
        {
            x.AddDebug();
            x.AddConsole();
        })
        .Build();

        host.Run();
    }
}