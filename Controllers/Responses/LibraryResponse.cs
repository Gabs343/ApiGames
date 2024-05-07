namespace ApiGames.Controllers.Responses
{
    public class LibraryResponse
    {
        public long Id { get; set; }
        public List<GameResponse> Games { get; set; }
    }
}
