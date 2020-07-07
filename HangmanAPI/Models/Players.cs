using System.ComponentModel.DataAnnotations;

namespace HangmanAPI.Models
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