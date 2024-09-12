public class Song // Class to represent a song in the database
{
    public int Id { get; set; } // Property to hold the unique identifier for the song
    public string Title { get; set; } // Property to hold the title of the song
    public string Artist { get; set; } // Property to hold the artist of the song
    public string Album { get; set; } // Property to hold the album name of the song
    public string ReleaseDate { get; set; } // Property to hold the release date of the song
}