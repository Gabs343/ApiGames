using ApiGames.Models;
using ApiGames.Repositories;

namespace ApiGames.Services {
    public class GameService : IGameService {
        private readonly IGameRepository _repository;
        private readonly ITagService _tagService;

        public GameService(IGameRepository repository, ITagService tagService) {
            _repository = repository;
            _tagService = tagService;
        }

        public List<Game> GetAllGames() {
            return _repository.GetAll();
        }

        public async Task<Game> FindById(long id) {
            Game? game = await _repository.FindById(id);
            if (game != null) { return game; }
            throw new Exception($"Cannot find the game with the id: {id}");
        }

        public async Task<Game> Save(Game? game) {
            if (game == null) throw new Exception($"The Game cannot be null");
            _repository.Insert(game);
            await _repository.Save();
            return game;
        }

        public async Task<Game> AddTagsToGame(Game game, List<long> tagsIds) {
            foreach (long tagId in tagsIds) {
                try {
                    Tag tag = await _tagService.FindById(tagId);
                    game.AddTag(tag);
  
                } catch (Exception) { }

            }
            await _repository.Save();
            return game;
        }

        public async Task<Game> RemoveTagsToGame(Game game, List<long> tagsIds) {
            foreach (long tagId in tagsIds) {
                try {
                    Tag tag = await _tagService.FindById(tagId);
                    game.RemoveTag(tag);

                } catch (Exception) { }

            }
            await _repository.Save();
            return game;
        }
    }
}
