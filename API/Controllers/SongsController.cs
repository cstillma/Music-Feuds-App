using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public SongsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Song>> Get()
        {
            return await _context.Songs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Song> Get(int id)
        {
            return await _context.Songs.FindAsync(id);
        }

        [HttpPost]
        public async Task<Song> Post(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
            return song;
        }

        [HttpPut("{id}")]
        public async Task<Song> Put(int id, Song song)
        {
            _context.Entry(song).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return song;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
        }
    }
}