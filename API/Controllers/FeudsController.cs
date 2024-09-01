using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeudsController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IFeudsServices _feudsServices;

        public FeudsController(MyDbContext context, IFeudsServices feudsServices)
        {
            _context = context;
            _feudsServices = feudsServices;
        }

        [HttpGet("ui/{id}")]
        public async Task<FeudUI> GetFeudForUser(int id)
        {
            return await _feudsServices.GetFeudByIdAsync(id);
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