using HangmanAPI.Data;
using HangmanAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HangmanAPI.Controllers
{
  /// <summary>
  /// Current Player Statistics
  /// </summary>
  [EnableCors("AllowAllHeaders")]
  [ApiController]
  [Route("[controller]")]
  public class PlayersStatisticsController : ControllerBase
  {
    /// <summary>
    /// Db appplication Context
    /// </summary>
    private readonly ApplicationDbContext context;

    /// <summary>
    /// Default Constructor of the Controller
    /// </summary>
    /// <param name="context">DB application context</param>
    public PlayersStatisticsController(ApplicationDbContext context)
    {
      this.context = context;
    }

    /// <summary>
    /// Get the current Statistics of a Player
    /// </summary>
    /// <param name="username">Username of the Player</param>
    /// <param name="categoryId">Category of the Game</param>
    /// <returns>A Player Statustics Data</returns>
    [HttpGet("{username}/{categoryId}", Name = "getStats")]
    public async Task<ActionResult<PlayersStatistics>> Get(string username, int categoryId)
    {
      var player = await context.Players.FirstOrDefaultAsync(x => x.Username == username);
      return await context.PlayersStatistics.FirstOrDefaultAsync(x => x.PlayerId == player.Id && x.CategoryId == categoryId) ?? new PlayersStatistics();
    }

    /// <summary>
    /// Register new Player Statistics
    /// </summary>
    /// <param name="stats">PlayersStatistics Object</param>
    /// <returns>No Content</returns>
    [HttpPost]
    public async Task<ActionResult> Post(PlayersStatistics stats)
    {
      context.Add(stats);
      await context.SaveChangesAsync();
      return NoContent();
    }

    /// <summary>
    /// Update Player Statistics
    /// </summary>
    /// <param name="stats">PlayersStatistics Object</param>
    /// <returns>No Content</returns>
    [HttpPut]
    public async Task<ActionResult> Put(PlayersStatistics stats)
    {
      context.Entry(stats).State = EntityState.Modified;
      await context.SaveChangesAsync();
      return NoContent();
    }
  }
}