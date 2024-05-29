namespace ApiGames.Models {
    public class Wishlist {
        public long Id { get; set; }
        public User User { get; set; } = null!;
        public List<Game> Games { get; set; }

        public Wishlist() {
            Games = new List<Game>();
        }
        public Wishlist(long id) {
            Id = id;
            Games = new List<Game>();
        }

        public bool HasGame(long id) {
            return Games.Any(g => g.Id == id);
        }

        public void AddGame(Game game) {
            if (Games == null) Games = new List<Game>();
            if (!HasGame(game.Id)) {
                Games.Add(game);
            }
        }

        public void RemoveGame(Game game) {
            if (HasGame(game.Id)) {
                Games.Remove(game);
            }
        }
    }
}
