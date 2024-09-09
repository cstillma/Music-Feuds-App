public class FeudUI // Class to hold the feud information to be displayed in the UI
{
    public int Id { get; set; } // Property to hold the unique identifier for the feud
    public string FeudName { get; set; } // Property to hold the name of the feud
    public List<Song> FeudSongs { get; set; } // Property to hold the songs associated with the feud
}