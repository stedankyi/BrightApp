namespace BrightApp.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task Login(UserLogin user);

        Task Register(User user);
    }
}
