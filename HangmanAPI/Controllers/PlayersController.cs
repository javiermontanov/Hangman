using HangmanAPI.Data;
using HangmanAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HangmanAPI.Controllers
{
  /// <summary>
  /// Players of Game
  /// </summary>
  [EnableCors("AllowAllHeaders")]
  [ApiController]
  [Route("[controller]")]
  public class PlayersController : ControllerBase
  {
    /// <summary>
    /// Db appplication Context
    /// </summary>
    private readonly ApplicationDbContext context;

    /// <summary>
    /// Default Constructor of the Controller
    /// </summary>
    /// <param name="context">DB application context</param>
    public PlayersController(ApplicationDbContext context)
    {
      this.context = context;
    }

    /// <summary>
    /// Obtain all the data from the player
    /// </summary>
    /// <param name="username">Username of the Player</param>
    /// <returns></returns>
    [HttpGet("{username}", Name = "verifyLogin")]
    public async Task<ActionResult<Players>> Get(string username)
    {
      return await context.Players.FirstOrDefaultAsync(x => x.Username == username);
    }

    /// <summary>
    /// Verify the submitted player to start session 
    /// </summary>
    /// <param name="player">Player object</param>
    /// <returns>The expected username if the player exists or else a bad request</returns>
    [HttpPost]
    public async Task<ActionResult> Post(Players player)
    {
      var sha1 = new SHA1CryptoServiceProvider();

      if (!UserWithTheSameUsernameExists(player.Username))
      {
        player.Password = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(player.Password)));
        context.Add(player);
        await context.SaveChangesAsync();
        return new CreatedAtRouteResult("verifyLogin",
          new { username = player.Username }, player);
      }
      else
      {
        return BadRequest();
      }
    }

    /// <summary>
    /// Verify if another player has the same username
    /// </summary>
    /// <param name="username">Username of the Player</param>
    /// <returns>True or False</returns>
    public bool UserWithTheSameUsernameExists(string username)
    {
      return context.Players.Any(u => u.Username == username);
    }

    /// <summary>
    /// Register a new Player
    /// </summary>
    /// <param name="player">Player object</param>
    /// <returns>if registration is ok returns a Ok Object Result</returns>
    [HttpPut]
    public async Task<ActionResult<Players>> Put(Players player)
    {
      var sha1 = new SHA1CryptoServiceProvider();
      var password = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(player.Password)));
      Players cPlayer = await context.Players.FirstOrDefaultAsync(
        x => x.Username == player.Username && x.Password == password) ?? new Players();

      return new OkObjectResult(cPlayer);
    }
  }
}