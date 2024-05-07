using ApiGames.Models;

namespace ApiGames.Repositories
{
    public interface ILibraryRepository
    {
        public Task<Library?> FindById(long id);

        public Task Save();
    }
}
