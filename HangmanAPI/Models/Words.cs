namespace HangmanAPI.Models
{
  /// <summary>
  /// Words Model
  /// </summary>
  public class Words
  {
    /// <summary>
    /// The Words Id
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// The Text of the world
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    /// The Difficulty of the world
    /// </summary>
    public int Difficulty { get; set; }
    
    /// <summary>
    /// The Category of the word
    /// </summary>
    public int CategoryId { get; set; }
    
    /// <summary>
    /// The Object Category of the word
    /// </summary>
    public WordsCategories Category { get; set; }
  }
}