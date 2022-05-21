namespace Meowie.Lib.Services
{
    public interface ILocationService
    {
     
        Task<Services.Location> GetLocationAsync();
    }
}
