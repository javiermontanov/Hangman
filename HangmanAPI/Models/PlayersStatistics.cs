namespace HangmanAPI.Models
{
  /// <summary>
  /// PlayersStatistics Model
  /// </summary>
  public class PlayersStatistics
  {
    /// <summary>
    /// The if of PlayersStatistics
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// The Player Id
    /// </summary>
    public int PlayerId { get; set; }
    
    /// <summary>
    /// The Player Object
    /// </summary>
    public Players Player { get; set; }
    
    /// <summary>
    /// The Category Id
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// The WordsCategories Object
    /// </summary>
    public WordsCategories Category { get; set; }
    
    /// <summary>
    /// The number of wins
    /// </summary>
    public int Win { get; set; }
    
    /// <summary>
    /// The number of losses
    /// </summary>
    public int Loss { get; set; }
    
    /// <summary>
    /// The number of abandoned games
    /// </summary>
    public int Abandon { get; set; }
  }
}