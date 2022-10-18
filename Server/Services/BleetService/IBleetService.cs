namespace BrightApp.Server.Services.BleetService
{
    public interface IBleetService
    {
        Task<List<Bleet>> GetBleetsAsync();

        Task<Bleet> CreateBleet(Bleet bleet);
    }
}
