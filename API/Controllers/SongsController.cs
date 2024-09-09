using Microsoft.AspNetCore.Mvc; // Importing ASP.NET Core MVC for controller functionalities
using Microsoft.EntityFrameworkCore; // Importing Entity Framework Core for database operations

namespace API.Controllers
{
    [ApiController] // Indicates that this class is an API controller
    [Route("[controller]")] // Defines the route for this controller, using the controller's name
    public class SongsController : ControllerBase
    {
        private readonly MyDbContext _context; // Field to hold the database context

        // Constructor to initialize the database context and songs services
        public SongsController(MyDbContext context)
        {
            _context = context; // Assigning the database context
        }

        [HttpGet] // HTTP GET endpoint to get all songs
        public async Task<IEnumerable<Song>> Get()
        {
            return await _context.Songs.ToListAsync(); // Retrieves all songs from the database asynchronously
        }

        [HttpGet("{id}")] // HTTP GET endpoint to get a song by ID
        public async Task<Song> Get(int id)
        {
            return await _context.Songs.FindAsync(id); // Finds and returns the song with the specified ID asynchronously
        }

        [HttpPost] // HTTP POST endpoint to create a new song
        public async Task<Song> Post(Song song)
        {
            _context.Songs.Add(song); // Adds the new song to the context
            await _context.SaveChangesAsync(); // Saves the changes to the database asynchronously
            return song; // Returns the created song
        }

        [HttpPut("{id}")] // HTTP PUT endpoint to update an existing song by ID
        public async Task<Song> Put(int id, Song song)
        {
            _context.Entry(song).State = EntityState.Modified; // Marks the song entity as modified
            await _context.SaveChangesAsync(); // Saves the changes to the database asynchronously
            return song; // Returns the updated song
        }

        [HttpDelete("{id}")] // HTTP DELETE endpoint to delete a song by ID
        public async Task Delete(int id)
        {
            var song = await _context.Songs.FindAsync(id); // Finds the song with the specified ID asynchronously
            _context.Songs.Remove(song); // Removes the song from the context
            await _context.SaveChangesAsync(); // Saves the changes to the database asynchronously
        }
    }
}