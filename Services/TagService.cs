using ApiGames.Models;
using ApiGames.Repositories;

namespace ApiGames.Services {
    public class TagService : ITagService {
        private readonly ITagRepository _repository;

        public TagService(ITagRepository repository) {
            _repository = repository;
        }

        public List<Tag> GetAllTags() {
            return _repository.GetAll();
        }

        public async Task<Tag> FindById(long id) {
            Tag? tag = await _repository.FindById(id);
            if (tag != null) { return tag; }
            throw new Exception($"Cannot find the tag with the id: {id}");

        }

        public async Task<Tag> Save(Tag? tag) {
            if (tag == null) { throw new Exception($"The Tag cannot be null"); }
            _repository.Insert(tag);
            await _repository.Save();
            return tag;
        }
    }
}
