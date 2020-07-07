using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace HangmanAPI
{
  /// <summary>
  /// Program Class to configure the Api
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Static Main
    /// </summary>
    /// <param name="args">Parameters of the Program</param>
    public static void Main(string[] args)
    {
      BuildWebHost(args).Run();
    }

    /// <summary>
    /// Default Build Web Host
    /// </summary>
    /// <param name="args">Arguments for the Web Host</param>
    /// <returns>None</returns>
    public static IWebHost BuildWebHost(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
        .UseConfiguration(new ConfigurationBuilder()
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddCommandLine(args)
          .Build())
        .UseStartup<Startup>()
        .Build();
  }
}