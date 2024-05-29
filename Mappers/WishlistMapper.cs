using ApiGames.Controllers.Responses;
using ApiGames.Models;

namespace ApiGames.Mappers
{
    public static class WishlistMapper
    {
        public static WishlistResponse GetWishlistResponseFromWishlist(Wishlist wishlist) {
            return new WishlistResponse {
                Id = wishlist.Id,
                Games = GameMapper.GetGamesResponseFromGames(wishlist.Games)
            };
        }
    }
}
