﻿namespace HangmanWebApp.Models
{
  public class Words
  {
    public int Id { get; set; }
    public string Text { get; set; }
    public int Difficulty { get; set; }
    public int CategoryId { get; set; }
  }
}