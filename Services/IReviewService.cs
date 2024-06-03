using ApiGames.Models;

namespace ApiGames.Services {
    public interface IReviewService {
        public List<Review> GetReviews();

        public Task<Review> Save(Review review);
    }
}
