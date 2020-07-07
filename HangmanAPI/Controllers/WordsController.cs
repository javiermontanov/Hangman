using HangmanAPI.Data;
using HangmanAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanAPI.Controllers
{
  /// <summary>
  /// Words of the Game
  /// </summary>
  [EnableCors("AllowAllHeaders")]
  [ApiController]
  [Route("[controller]")]
  public class WordsController : ControllerBase
  {
    /// <summary>
    /// Db appplication Context
    /// </summary>
    private readonly ApplicationDbContext context;

    /// <summary>
    /// Default Constructor of the Controller
    /// </summary>
    /// <param name="context">DB application contex</param>
    public WordsController(ApplicationDbContext context)
    {
      this.context = context;
    }

    /// <summary>
    /// Return the next available word in the game
    /// </summary>
    /// <param name="word">A Word object</param>
    /// <returns>The nex word object avaible for the current player</returns>
    [HttpPut]
    public async Task<ActionResult<Words>> Put(Words word)
    {
      Words cword = await context.Words.OrderBy(x => x.Difficulty).FirstOrDefaultAsync(
        x => x.CategoryId == word.CategoryId && x.Difficulty > word.Difficulty) ?? new Words();

      return new OkObjectResult(cword);
    }
  }
}