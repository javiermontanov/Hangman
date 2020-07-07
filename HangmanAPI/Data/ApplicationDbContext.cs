using HangmanAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HangmanAPI.Data
{
  /// <summary>
  /// Application Db Context
  /// </summary>
  public class ApplicationDbContext : DbContext
  {
    /// <summary>
    /// Default Contructor
    /// </summary>
    /// <param name="options">Db context options</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// DbSet for Words Model
    /// </summary>
    public DbSet<Words> Words { get; set; }

    /// <summary>
    /// DbSet for Words Categories Model
    /// </summary>
    public DbSet<WordsCategories> WordsCategories { get; set; }

    /// <summary>
    /// DbSet for Players Model
    /// </summary>
    public DbSet<Players> Players { get; set; }

    /// <summary>
    /// DbSet for Player Statistics Model
    /// </summary>
    public DbSet<PlayersStatistics> PlayersStatistics { get; set; }
  }
}