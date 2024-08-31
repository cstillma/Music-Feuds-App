namespace API.Services
{
    public interface IFeudsServices
    {
        Task<FeudUI> GetFeudByIdAsync(int id);
    }
}