using ApiGames.Data;
using ApiGames.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGames.Repositories {
    public class WishlistRepository : IWishlistRepository {

        private readonly MyContext _context;

        public WishlistRepository(MyContext context) {
            _context = context;
        }
        public async Task<Wishlist?> FindById(long id) {
            return await _context.wishlists
                .Include(wsh => wsh.Games)
                .ThenInclude(gms => gms.Tags)
                .FirstOrDefaultAsync(wsh => wsh.Id == id);
        }

        public async Task Save() {
            await _context.SaveChangesAsync();
        }
    }
}
