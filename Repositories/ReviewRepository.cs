using ApiGames.Data;
using ApiGames.Models;

namespace ApiGames.Repositories {
    public class ReviewRepository : IReviewRepository {

        private readonly MyContext _context;

        public ReviewRepository(MyContext context) {
            _context = context;
        }

        public List<Review> GetAll() {
            return _context.reviews.ToList();
        }

        public void Insert(Review review) {
            _context.reviews.Add(review);
        }

        public async Task Save() {
            await _context.SaveChangesAsync();
        }
    }
}
