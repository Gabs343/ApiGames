namespace ApiGames.Models
{
    public class Library
    {
        public long Id { get; set; }
        public User User { get; set; } = null!;
        public List<Game> Games { get; set; }

        public Library() { 
            Games = new List<Game>();
        }
        public Library(long id)
        {
            Id = id;
            Games = new List<Game>();
        }

        public void AddGame(Game game) {
            if(Games == null) Games = new List<Game>();
            Games.Add(game);
        }
    }
}
