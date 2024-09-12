using Microsoft.EntityFrameworkCore; // Importing Entity Framework Core for database operations
using API;
using API.Services;

var builder = WebApplication.CreateBuilder(args); // Creating a builder for the web application

// Add services to the container.
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["DBConnString"]); // Configuring the DbContext to use SQL Server with a connection string from configuration
});

builder.Services.AddScoped<IFeudsServices, FeudsServices>(); // Registering FeudsServices with the dependency injection container
builder.Services.AddControllers(); // Adding controllers to the service collection

// Add CORS service and configure the policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:3000") // Allowing requests from the specified origin
                          .AllowAnyHeader() // Allowing any headers
                          .AllowAnyMethod()); // Allowing any HTTP methods
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // Adding support for API endpoint exploration
builder.Services.AddSwaggerGen(); // Adding Swagger generation for API documentation

var app = builder.Build(); // Building the web application

app.UseCors("AllowSpecificOrigin"); // Enabling the CORS policy defined earlier

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Checking if the environment is Development
{
    app.UseSwagger(); // Enabling Swagger middleware for API documentation in development
    app.UseSwaggerUI(); // Enables the Swagger UI middleware, which provides a web-based interface for exploring and testing the API endpoints
}

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS for security

app.UseAuthorization(); // Adds authorization middleware to the request pipeline

app.MapControllers(); // Maps attribute-routed controllers to the request pipeline

app.Run(); // Runs the application and blocks the calling thread until the host shuts down
