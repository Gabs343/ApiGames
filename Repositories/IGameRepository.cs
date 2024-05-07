using ApiGames.Models;

namespace ApiGames.Repositories
{
    public interface IGameRepository
    {
        public List<Game> GetAll();

        public Task<Game?> FindById(long id);

        public void Insert(Game game);

        public Task Save();

    }
}
