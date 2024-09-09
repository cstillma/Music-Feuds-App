using Microsoft.AspNetCore.Mvc; // Importing ASP.NET Core MVC for controller functionalities
using Microsoft.EntityFrameworkCore; // Importing Entity Framework Core for database operations

namespace API.Controllers
{
    [ApiController] // Indicates that this class is an API controller
    [Route("[controller]")] // Defines the route for this controller, using the controller's name
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _context; // Field to hold the database context

        // Constructor to initialize the database context and users services
        public UsersController(MyDbContext context)
        {
            _context = context; // Assigning the database context
        }

        [HttpGet] // HTTP GET endpoint to get all users
        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.ToListAsync(); // Retrieves all users from the database asynchronously
        }

        [HttpGet("{id}")] // HTTP GET endpoint to get a user by ID
        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id); // Finds and returns the user with the specified ID asynchronously
        }

        [HttpPost] // HTTP POST endpoint to create a new user
        public async Task<User> Post(User user)
        {
            _context.Users.Add(user); // Adds the new user to the context
            await _context.SaveChangesAsync(); // Saves the changes to the database asynchronously
            return user; // Returns the created user
        }

        [HttpPut("{id}")] // HTTP PUT endpoint to update an existing user by ID
        public async Task<User> Put(int id, User user)
        {
            _context.Entry(user).State = EntityState.Modified; // Marks the user entity as modified
            await _context.SaveChangesAsync(); // Saves the changes to the database asynchronously
            return user; // Returns the updated user
        }

        [HttpDelete("{id}")] // HTTP DELETE endpoint to delete a user by ID
        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id); // Finds the user with the specified ID asynchronously
            _context.Users.Remove(user); // Removes the user from the context
            await _context.SaveChangesAsync(); // Saves the changes to the database asynchronously
        }
    }
}