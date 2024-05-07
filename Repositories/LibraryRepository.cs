using ApiGames.Data;
using ApiGames.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGames.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly MyContext _context;

        public LibraryRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<Library?> FindById(long id)
        {
            return await _context.libraries
                .Include(lbs => lbs.Games)
                .ThenInclude(gms => gms.Tags)
                .FirstOrDefaultAsync(lbs => lbs.Id == id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
