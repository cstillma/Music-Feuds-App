using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeudsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public FeudsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("/ui/{id}")]
        public async Task<FeudUI> GetFeudForUser(int id)
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

        [HttpGet]
        public async Task<IEnumerable<Feud>> Get()
        {
            return await _context.Feuds.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Feud> Get(int id)
        {
            return await _context.Feuds.FindAsync(id);
        }

        [HttpPost]
        public async Task<Feud> Post(Feud feud)
        {
            _context.Feuds.Add(feud);
            await _context.SaveChangesAsync();
            return feud;
        }

        [HttpPut("{id}")]
        public async Task<Feud> Put(int id, Feud feud)
        {
            _context.Entry(feud).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return feud;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var feud = await _context.Feuds.FindAsync(id);
            _context.Feuds.Remove(feud);
            await _context.SaveChangesAsync();
        }
    }
}