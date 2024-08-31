using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class FeudsServices : IFeudsServices
{
    private readonly MyDbContext _context;

    public FeudsServices(MyDbContext context)
    {
        _context = context;
    }

    public async Task<FeudUI> GetFeudByIdAsync(int id)
    {
            Feud feud = await _context.Feuds.FindAsync(id);
            // make a list of song ids from the string of song ids
            var songIds = feud.FeudSongs.Split(',');

            //convert each song id from a string to an int
            var songIdsInt = songIds.Select(s => int.Parse(s)).ToList();

            IEnumerable<Song> songs = await _context.Songs.Where(s => songIdsInt.Contains(s.Id)).ToListAsync();

            FeudUI feudUI = new FeudUI
            {
                Id = feud.Id,
                FeudName = feud.FeudName,
                FeudSongs = songs.ToList()
            };
            return feudUI;
    }
}