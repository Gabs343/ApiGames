using ApiGames.Models;
using ApiGames.Repositories;

namespace ApiGames.Services {
    public class LibraryService : ILibraryService {
        private readonly ILibraryRepository _repository;
        private readonly IGameService _gameService;

        public LibraryService(ILibraryRepository repository,
                              IGameService gameService) {
            _repository = repository;
            _gameService = gameService;
        }

        public async Task<Library> AddGamesToLibrary(Library library, List<long> gamesIds) {
            List<Game>  games = _gameService.FindByIds(gamesIds);
            games.ForEach(library.AddGame);
            await _repository.Save();
            return library;
        }

        public async Task<Library> FindById(long id) {
            Library? library = await _repository.FindById(id);
            if (library != null) { return library; }
            throw new Exception("There is a problem in finding the library");
        }
    }
}
