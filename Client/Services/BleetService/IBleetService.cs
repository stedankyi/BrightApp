namespace BrightApp.Client.Services.BleetService
{
    public interface IBleetService
    {
        List<Bleet> Bleets { get; set; }
        Task GetBleets();
    }
}
