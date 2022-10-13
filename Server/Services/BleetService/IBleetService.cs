namespace BrightApp.Server.Services.BleetService
{
    public interface IBleetService
    {
        Task<ServiceResponse<List<Bleet>>> GetBleetsAsync();
    }
}
