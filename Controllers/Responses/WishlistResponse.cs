namespace ApiGames.Controllers.Responses {
    public class WishlistResponse {
        public long Id { get; set; }
        public List<GameResponse> Games { get; set; }
    }
}
