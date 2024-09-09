using Microsoft.EntityFrameworkCore; 

namespace API.Services;

public class FeudsServices : IFeudsServices // Class to handle the business logic for feuds
{
    private readonly MyDbContext _context; // Private field to hold the database context

    public FeudsServices(MyDbContext context) // Constructor to initialize the database context
    {
        _context = context; // Assign the injected database context to the private field
    }

    public async Task<FeudUI> GetFeudByIdAsync(int id) // Method to get a feud by its unique identifier
        {
            Feud feud = await _context.Feuds.FindAsync(id); // Find the feud in the database by its unique identifier
            // make a list of song ids from the string of song ids
            var songIds = feud.FeudSongs.Split(','); 

            // convert each song id from a string to an int
            var songIdsInt = songIds.Select(s => int.Parse(s)).ToList();

            IEnumerable<Song> songs = await _context.Songs.Where(s => songIdsInt.Contains(s.Id)).ToListAsync(); // Retrieve the songs associated with the feud
            
            FeudUI feudUI = new FeudUI // Create a new FeudUI object with the feud and its associated songs
            {
                Id = feud.Id, // Assign the feud's unique identifier
                FeudName = feud.FeudName, // Assign the feud's name
                FeudSongs = songs.ToList() // Assign the list of associated songs
            };
            return feudUI; // Return the FeudUI object
        }
}