using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SugestaoDeProdutos;

/// <summary>
/// Class Program.
/// </summary>
public static class Program
{
    /// <summary>
    /// The entry point of the application.
    /// </summary>
    /// <param name="args">An array of command-line arguments passed to the application.</param>
    /// <remarks>
    /// This method initializes the application by creating a host builder, building the host, and then running it.
    /// The host is responsible for managing the application's services and lifecycle. 
    /// This is typically where the application starts its execution, setting up any necessary configurations 
    /// and dependencies before entering the main execution loop.
    /// </remarks>
    public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

    /// <summary>
    /// Creates a host builder for the application.
    /// </summary>
    /// <param name="args">An array of command-line arguments.</param>
    /// <returns>An instance of <see cref="IHostBuilder"/> configured for the application.</returns>
    /// <remarks>
    /// This method initializes a new instance of the host builder using the default configuration settings.
    /// It sets up the web host with default configurations and specifies the startup class to be used for the application.
    /// The <paramref name="args"/> parameter allows for command-line arguments to be passed, which can be utilized for configuration purposes.
    /// This setup is essential for running ASP.NET Core applications, as it establishes the necessary environment and services required for the application to function.
    /// </remarks>
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
}
