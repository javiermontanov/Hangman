using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;

namespace HangmanWebApp
{
  /// <summary>
  /// Program Class to configure the Web App
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Main method of the Program
    /// </summary>
    /// <param name="args">Current Arguments</param>
    /// <returns>None</returns>
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("app");

      builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }).AddStorage();

      await builder.Build().RunAsync();
    }
  }
}
