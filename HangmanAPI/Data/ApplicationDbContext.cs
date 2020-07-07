using HangmanAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HangmanAPI.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Words> Words { get; set; }
    public DbSet<WordsCategories> WordsCategories { get; set; }
    public DbSet<Players> Players { get; set; }
    public DbSet<PlayersStatistics> PlayersStatistics { get; set; }
  }
}