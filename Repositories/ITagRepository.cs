using ApiGames.Models;

namespace ApiGames.Repositories
{
    public interface ITagRepository
    {
        public List<Tag> GetAll();

        public Task<Tag?> FindById(long id);

        public void Insert(Tag tag);

        public Task Save();
    }
}
