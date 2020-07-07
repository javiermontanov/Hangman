using HangmanAPI.Data;
using HangmanAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HangmanAPI.Controllers
{
  [EnableCors("AllowAllHeaders")]
  [ApiController]
  [Route("[controller]")]
  public class PlayersStatisticsController : ControllerBase
  {
    private readonly ApplicationDbContext context;

    public PlayersStatisticsController(ApplicationDbContext context)
    {
      this.context = context;
    }

    [HttpGet("{username}/{categoryId}", Name = "getStats")]
    public async Task<ActionResult<PlayersStatistics>> Get(string username, int categoryId)
    {
      var player = await context.Players.FirstOrDefaultAsync(x => x.Username == username);
      return await context.PlayersStatistics.FirstOrDefaultAsync(x => x.PlayerId == player.Id && x.CategoryId == categoryId) ?? new PlayersStatistics();
    }

    [HttpPost]
    public async Task<ActionResult> Post(PlayersStatistics stats)
    {
      context.Add(stats);
      await context.SaveChangesAsync();
      return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> Put(PlayersStatistics stats)
    {
      context.Entry(stats).State = EntityState.Modified;
      await context.SaveChangesAsync();
      return NoContent();
    }
  }
}