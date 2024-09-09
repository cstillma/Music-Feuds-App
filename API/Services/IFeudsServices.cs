namespace API.Services
{
    public interface IFeudsServices // Interface for the FeudsServices class
    {
        Task<FeudUI> GetFeudByIdAsync(int id); // Method to get a feud by its unique identifier
    }
}