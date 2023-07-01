using Library.DbModels.FluentModels;

namespace Library.Services
{
    public interface IAuthService
    {
        Task<Fluent_User> Register(Fluent_User user, string password);
        Task<Fluent_User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
