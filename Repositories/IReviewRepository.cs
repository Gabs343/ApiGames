using ApiGames.Models;

namespace ApiGames.Repositories {
    public interface IReviewRepository {

        public List<Review> GetAll();

        public void Insert(Review review);

        public Task Save();
    }
}
