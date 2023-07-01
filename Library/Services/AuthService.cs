using Library.DbModels.FluentModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class AuthService : IAuthService
    {
        private readonly LibraryContext _context;

        public AuthService(LibraryContext context)
        {
            _context = context;
        }
        public async Task<Fluent_User> Login(string username, string password)
        {
            var user = await _context.Fluent_Users.Include(x => x.Reader).FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<Fluent_User> Register(Fluent_User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Fluent_Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            //if (await _context.Fluent_Users.AnyAsync(x => x.Username == username))
            //    return true;

            //return false;

            return await _context.Fluent_Users.AnyAsync(x => x.Username == username);
        }


        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
