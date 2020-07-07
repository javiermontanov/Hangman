using HangmanAPI.Data;
using HangmanAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanAPI.Controllers
{
  [EnableCors("AllowAllHeaders")]
  [ApiController]
  [Route("[controller]")]
  public class WordsController : ControllerBase
  {
    private readonly ApplicationDbContext context;

    public WordsController(ApplicationDbContext context)
    {
      this.context = context;
    }

    [HttpPut]
    public async Task<ActionResult<Words>> Put(Words word)
    {
      Words cword = await context.Words.OrderBy(x => x.Difficulty).FirstOrDefaultAsync(
        x => x.CategoryId == word.CategoryId && x.Difficulty > word.Difficulty) ?? new Words();

      return new OkObjectResult(cword);
    }
  }
}