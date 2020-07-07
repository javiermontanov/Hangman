using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanWebApp.Models
{
  /// <summary>
  /// Players Model
  /// </summary>
  public class Players
  {
    /// <summary>
    /// The Id of the Player
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The username of the Player
    /// </summary>
    [Required]
    public string Username { get; set; }

    /// <summary>
    /// The Password of the Player
    /// </summary>
    [Required]
    public string Password { get; set; }
  }
}