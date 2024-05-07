using ApiGames.Models;

namespace ApiGames.Services
{
    public interface IGameService
    {
        public List<Game> GetAllGames();

        public Task<Game> Save(Game? game);

        public Task<Game> FindById(long id);

        public Task<Game> AddTagsToGame(Game game, List<long> tagsIds);

        public Task<Game> RemoveTagsToGame(Game game, List<long> tagsIds);
    }
}
