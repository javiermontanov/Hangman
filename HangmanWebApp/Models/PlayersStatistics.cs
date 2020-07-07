namespace HangmanWebApp.Models
{
  public class PlayersStatistics
  {
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public Players Player { get; set; }
    public int CategoryId { get; set; }
    public int Win { get; set; }
    public int Loss { get; set; }
    public int Abandon { get; set; }
  }
}