namespace ApiGames.Controllers.Responses
{
    public class GameResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<TagResponse> Tags { get; set; }
    }
}
