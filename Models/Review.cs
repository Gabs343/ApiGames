namespace ApiGames.Models {
    public class Review {
        public long Id { get; set; }

        public DateTime PostedAt { get; set; }

        public string Message { get; set; }

        public bool IsRecommended { get; set; }

        public long UserId { get; set; }

        public long GameId { get; set; }

        public User User { get; set; }

        public Game Game { get; set; }

        public Review() { }

        public Review(long id, DateTime postedAt, string message, bool isRecommended, User user, Game game) {
            Id = id;
            PostedAt = postedAt;
            IsRecommended = isRecommended;
            Message = message;
            User = user;
            Game = game;
        }


    }
}
