using ApiGames.Models;
using ApiGames.Repositories;

namespace ApiGames.Services {
    public class ReviewService : IReviewService {

        private readonly IReviewRepository _repository;
        private readonly IUserService _userService;
        private readonly IGameService _gameService;

        public ReviewService(IReviewRepository repository,
                            IUserService userService,
                            IGameService gameService) {
            _repository = repository;
            _userService = userService;
            _gameService = gameService;
        }

        public List<Review> GetReviews() {
            return _repository.GetAll();
        }

        public async Task<Review> Save(Review review) {
            Game game = await GetGameById(review.GameId);
            User user = await GetUserById(review.UserId);

            review = new Review { 
                PostedAt = review.PostedAt,
                IsRecommended = review.IsRecommended,
                Message = review.Message,
                UserId = user.Id,
                GameId = game.Id,
                User = user,
                Game = game,
            };
 
            _repository.Insert(review);
            return review;
        }

        private async Task<Game> GetGameById(long id) {
            return await _gameService.FindById(id);
        }

        private async Task<User> GetUserById(long id) {
            return await _userService.FindById(id);
        }
    }
}
