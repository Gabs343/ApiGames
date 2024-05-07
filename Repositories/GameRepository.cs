using ApiGames.Data;
using ApiGames.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGames.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly MyContext _context;

        public GameRepository(MyContext context)
        {
            _context = context;
        }
  
        public List<Game> GetAll() 
        { 
            return _context.games.Include(gms => gms.Tags).ToList();
        }

        public async Task<Game?> FindById(long id)
        {
            return await _context.games.Include(gms => gms.Tags)
                                .FirstOrDefaultAsync(gms => gms.Id == id);
        }

        public void Insert(Game game)
        {
            _context.games.Add(game);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
