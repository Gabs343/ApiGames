using ApiGames.Models;

namespace ApiGames.Services
{
    public interface ITagService
    {
        public List<Tag> GetAllTags();
        public Task<Tag> Save(Tag? tag);
        public Task<Tag> FindById(long id);

    }
}
