using ApiGames.Models;

namespace ApiGames.Repositories {
    public interface IWishlistRepository {
        public Task<Wishlist?> FindById(long id);

        public Task Save();
    }
}
