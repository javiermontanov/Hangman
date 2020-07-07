using System.ComponentModel.DataAnnotations;

namespace HangmanAPI.Models
{
  public class Players
  {
      public int Id { get; set; }
      [Required]
      public string Username { get; set; }
      [Required]
      public string Password { get; set; }
    }
}