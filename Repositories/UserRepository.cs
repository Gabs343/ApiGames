using ApiGames.Data;
using ApiGames.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGames.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyContext _context;

        public UserRepository(MyContext context) { 
            _context = context;
        }

        public Task<User?> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByMail(string mail)
        {
            return await _context.users.FirstAsync(usr => usr.Mail.Equals(mail));
        }

        public async Task<bool> ExistByMail(string mail)
        {
            return await _context.users.AnyAsync(usr => usr.Mail.Equals(mail));
        }

        public void Insert(User user)
        {
            _context.users.Add(user);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
