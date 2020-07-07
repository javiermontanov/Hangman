using HangmanAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HangmanAPI
{
  /// <summary>
  /// Startup Class
  /// </summary>
  public class Startup
  {
    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="configuration">IConfiguration interface</param>
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    /// <summary>
    /// Current Configuration
    /// </summary>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// Configure all the services
    /// </summary>
    /// <param name="services">Service Collection</param>
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy("AllowAllHeaders",
              builder =>
              {
                builder.AllowAnyOrigin()
                         .AllowAnyHeader()
                         .AllowAnyMethod();
              });
      });

      var server = Configuration["DBServer"] ?? "sqlserver";
      var port = Configuration["DBPort"] ?? "1433";
      var user = Configuration["DBUser"] ?? "sa";
      var password = Configuration["DBPassword"] ?? "RFv84-fxmt";
      var database = Configuration["Database"] ?? "HangmanDB";

      services.AddDbContext<ApplicationDbContext>(options => options
        .UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID={user};Password={password};"));
      services.AddControllers();
    }
    /// <summary>
    /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    /// </summary>
    /// <param name="app">Application Builder Object</param>
    /// <param name="env">Web Host Environment Object</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      /*if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }*/

      Extensions.ApplicationBuilderExtensions.UseDataSeeders(app);

      app.UseRouting();

      app.UseCors("AllowAllHeaders");

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}