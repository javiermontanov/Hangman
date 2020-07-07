using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanAPI.Models
{
  /// <summary>
  /// Records of the current game Model
  /// </summary>
  public class WinRecords
  {
    /// <summary>
    /// The current difficulty of the game
    /// </summary>
    public int Difficulty { get; set; }
    
    /// <summary>
    /// The current category selected
    /// </summary>
    public int CategoryId { get; set; }
  }
}
