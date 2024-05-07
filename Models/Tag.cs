namespace ApiGames.Models {
    public class Tag {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Game> Games { get; set; }

        public Tag() { }
        public Tag(long id, string name) {
            Id = id;
            Name = name;
            Games = new List<Game>();
        }

        public bool HasGame(long id) {
            return Games.Any(g => g.Id == id);
        }

        public void AddGame(Game game) {
            if (Games == null) Games = new List<Game>();
            if (!HasGame(game.Id)) {
                Games.Add(game);
                game.AddTag(this);
            }
        }

        public void RemoveGame(Game game) {
            if (HasGame(game.Id)) {
                Games.Remove(game);
                game.RemoveTag(this);
            }
        }
    }
}
