using ApiGames.Models;

namespace ApiGames.Services
{
    public interface IUserService
    {
        public Task<User> FindById(long id);
        public Task<User> FindByMail(string mail);
        public Task<bool> ExistByMail(string mail);
        public Task<User> Save(User user);
    }
}
