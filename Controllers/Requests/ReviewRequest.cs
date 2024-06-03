namespace ApiGames.Controllers.Requests {
    public class ReviewRequest {

        public string Message { get; set; }

        public bool IsRecommended { get; set; }

        public long UserId {  get; set; }

        public long GameId {  get; set; }
    }
}
