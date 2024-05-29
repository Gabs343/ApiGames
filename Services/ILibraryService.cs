using ApiGames.Models;

namespace ApiGames.Services
{
    public interface ILibraryService
    {
        public Task<Library> FindById(long id);

        public Task<Library> AddGamesToLibrary(Library library, List<long> gamesIds);

        public Task<List<long>?> GetMissingGamesIds(long id, List<long> gamesIds);
    }
}
