using HangmanAPI.Data;
using HangmanAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HangmanAPI.Controllers
{
  /// <summary>
  /// Words Categories for the Game
  /// </summary>
  [EnableCors("AllowAllHeaders")]
  [ApiController]
  [Route("[controller]")]
  public class WordsCategoriesController : ControllerBase
  {
    /// <summary>
    /// Db appplication Context
    /// </summary>
    private readonly ApplicationDbContext context;

    /// <summary>
    /// Default Constructor of the Controller
    /// </summary>
    /// <param name="context">DB application context</param>
    public WordsCategoriesController(ApplicationDbContext context)
    {
      this.context = context;
    }

    /// <summary>
    /// Get all the list of Categories
    /// </summary>
    /// <returns>The list of all Words Categories</returns>
    [HttpGet]
    public async Task<ActionResult<List<WordsCategories>>> Get()
    {
      return await context.WordsCategories.ToListAsync();
    }
  }
}