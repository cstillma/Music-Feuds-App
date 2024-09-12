using Microsoft.AspNetCore.Mvc; // Importing ASP.NET Core MVC for controller functionalities
using Microsoft.EntityFrameworkCore; // Importing Entity Framework Core for database operations
using API.Services;

namespace API.Controllers
{
    [ApiController] // Indicates that this class is an API controller
    [Route("[controller]")] // Defines the route for this controller, using the controller's name
    public class FeudsController : ControllerBase
    {
        private readonly MyDbContext _context; // Field to hold the database context
        private readonly IFeudsServices _feudsServices; // Field to hold the feuds services

        // Constructor to initialize the database context and feuds services
        public FeudsController(MyDbContext context, IFeudsServices feudsServices)
        {
            _context = context; // Assigning the database context
            _feudsServices = feudsServices; // Assigning the feuds services
        }

        [HttpGet("ui/{id}")] // HTTP GET endpoint to get a feud for a user by ID
        public async Task<FeudUI> GetFeudForUser(int id)
        {
            return await _feudsServices.GetFeudByIdAsync(id); // Calls the service to get the feud by ID asynchronously
        }
        
        [HttpGet] // HTTP GET endpoint to get all feuds
        public async Task<IEnumerable<Feud>> Get()
        {
            return await _context.Feuds.ToListAsync(); // Retrieves all feuds from the database asynchronously
        }

        [HttpGet("{id}")] // HTTP GET endpoint to get a feud by ID
        public async Task<Feud> Get(int id)
        {
            return await _context.Feuds.FindAsync(id); // Finds and returns the feud with the specified ID asynchronously
        }

        [HttpPost] // HTTP POST endpoint to create a new feud
        public async Task<Feud> Post(Feud feud)
        {
            _context.Feuds.Add(feud); // Adds the new feud to the context
            await _context.SaveChangesAsync(); // Saves the changes to the database asynchronously
            return feud; // Returns the created feud
        }

        [HttpPut("{id}")] // HTTP PUT endpoint to update an existing feud by ID
        public async Task<Feud> Put(int id, Feud feud)
        {
            _context.Entry(feud).State = EntityState.Modified; // Marks the feud entity as modified
            await _context.SaveChangesAsync(); // Saves the changes to the database asynchronously
            return feud; // Returns the updated feud
        }

        [HttpDelete("{id}")] // HTTP DELETE endpoint to delete a feud by ID
        public async Task Delete(int id)
        {
            var feud = await _context.Feuds.FindAsync(id); // Finds the feud with the specified ID asynchronously
            _context.Feuds.Remove(feud); // Removes the feud from the context
            await _context.SaveChangesAsync(); // Saves the changes to the database asynchronously
        }
    }
}