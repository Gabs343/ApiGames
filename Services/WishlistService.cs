using ApiGames.Models;
using ApiGames.Repositories;

namespace ApiGames.Services {
    public class WishlistService : IWishlistService {

        private readonly IWishlistRepository _repository;
        private readonly IGameService _gameService;

        public WishlistService(IWishlistRepository repository,
                               IGameService gameService) { 
            _repository = repository;
            _gameService = gameService;
        }

        public async Task<Wishlist> AddGamesToWishlist(Wishlist wishlist, List<long> gamesIds) {
            List<Game> games = _gameService.FindByIds(gamesIds);
            games.ForEach(wishlist.AddGame);
            await _repository.Save();
            return wishlist;
        }

        public async Task<Wishlist> RemoveGamesFromWishlist(Wishlist wishlist, List<Game> games) {
            games.ForEach(wishlist.RemoveGame);
            await _repository.Save();
            return wishlist;
        }

        public async Task<Wishlist> FindById(long id) {
            Wishlist? wishlist = await _repository.FindById(id);
            if (wishlist != null) { return wishlist; }
            throw new Exception("There is a problem in finding the wishlist");
        }
    }
}
