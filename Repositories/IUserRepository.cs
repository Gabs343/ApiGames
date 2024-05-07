using ApiGames.Models;

namespace ApiGames.Repositories
{
    public interface IUserRepository
    {
        public Task<User?> FindById(long id);

        public Task<User> FindByMail(string mail);

        public Task<bool> ExistByMail(string mail);

        public void Insert(User user);

        public Task Save();
    }
}
