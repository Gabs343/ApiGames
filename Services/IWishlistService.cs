using ApiGames.Models;

namespace ApiGames.Services {
    public interface IWishlistService {
        public Task<Wishlist> FindById(long id);

        public Task<Wishlist> AddGamesToWishlist(Wishlist wishlist, List<long> gamesIds);

        public Task<Wishlist> RemoveGamesFromWishlist(Wishlist wishlist, List<Game> games);
    }
}
