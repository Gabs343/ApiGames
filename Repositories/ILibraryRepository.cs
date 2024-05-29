using ApiGames.Models;

namespace ApiGames.Repositories
{
    public interface ILibraryRepository
    {
        public Task<Library?> FindById(long id);

        public Task<List<long>?> GetMissingGamesIds(long id, List<long> gamesIds);

        public Task Save();
    }
}
