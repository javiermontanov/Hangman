using HangmanAPI.Data;
using HangmanAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HangmanAPI.Controllers
{
  [EnableCors("AllowAllHeaders")]
  [ApiController]
  [Route("[controller]")]
  public class WordsCategoriesController : ControllerBase
  {
    private readonly ApplicationDbContext context;

    public WordsCategoriesController(ApplicationDbContext context)
    {
      this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<WordsCategories>>> Get()
    {
      return await context.WordsCategories.ToListAsync();
    }
  }
}