using ApiGames.Models;
using ApiGames.Repositories;

namespace ApiGames.Services {
    public class LibraryService : ILibraryService {
        private readonly ILibraryRepository _repository;
        private readonly IGameService _gameService;
        private readonly IWishlistService _wishlistService;

        public LibraryService(ILibraryRepository repository,
                              IGameService gameService,
                              IWishlistService wishlistService) {
            _repository = repository;
            _gameService = gameService;
            _wishlistService = wishlistService;
        }

        public async Task<Library> AddGamesToLibrary(Library library, List<long> gamesIds) {
            List<Game>  games = _gameService.FindByIds(gamesIds);
            games.ForEach(library.AddGame);
            await _repository.Save();
            await RemoveGamesFromWishlist(library.Id, games);
            return library;
        }

        public async Task<Library> FindById(long id) {
            Library? library = await _repository.FindById(id);
            if (library != null) { return library; }
            throw new Exception("There is a problem in finding the library");
        }

        public async Task<List<long>?> GetMissingGamesIds(long id, List<long> gamesIds) {
            return await _repository.GetMissingGamesIds(id, gamesIds);
        }

        private async Task RemoveGamesFromWishlist(long id, List<Game> games) {
            Wishlist wishlist = await _wishlistService.FindById(id);
            await _wishlistService.RemoveGamesFromWishlist(wishlist, games);
        }
    }
}
