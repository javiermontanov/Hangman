using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanWebApp.Models
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