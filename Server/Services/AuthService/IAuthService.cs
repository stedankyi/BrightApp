namespace BrightApp.Server.Services.AuthService
{
    public interface IAuthService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        string CreateToken(UserData user);
        void StorePassword(User user);
        Task<string> AuthenticateUser(UserLogin user);
    }
}
