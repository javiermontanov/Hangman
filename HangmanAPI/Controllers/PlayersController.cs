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
  [EnableCors("AllowAllHeaders")]
  [ApiController]
  [Route("[controller]")]
  public class PlayersController : ControllerBase
  {
    private readonly ApplicationDbContext context;

    public PlayersController(ApplicationDbContext context)
    {
      this.context = context;
    }

    [HttpGet("{username}", Name = "verifyLogin")]
    public async Task<ActionResult<Players>> Get(string username)
    {
      return await context.Players.FirstOrDefaultAsync(x => x.Username == username);
    }

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

    public bool UserWithTheSameUsernameExists(string username)
    {
      return context.Players.Any(u => u.Username == username);
    }

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