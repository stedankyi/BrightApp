using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BrightApp.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly BleetContext _context;

        public AuthService(IConfiguration configuration, BleetContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async void StorePassword(User user)
        {
            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            UserData userData = new()
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now
            };

            await _context.Users.AddAsync(userData);
            _context.SaveChanges();
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public string CreateToken(UserData user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<string> AuthenticateUser(UserLogin user)
        {
            //var databaseEntry = _context.Users.Where(u => u.Username.Contains(user.Username)); 


            var databaseEntry = await _context.Users
                .Where(u => u.Username == user.Username).FirstOrDefaultAsync();



            if (databaseEntry == null) return "User does not exist";

            if (!(databaseEntry.Username == user.Username))
            {
                return "User not found";
            }

            if (!VerifyPasswordHash(user.Password, databaseEntry.PasswordHash, databaseEntry.PasswordSalt))
            {
                return "Wrong Password.";
            }

            string token = CreateToken(databaseEntry);

            return token;

        }
    }
}
