using ApiGames.Controllers.Requests;
using ApiGames.Controllers.Responses;
using ApiGames.Models;

namespace ApiGames.Mappers {
    public static class GameMapper {
        public static Game GetGameFromGameRequest(GameRequest request) {
            return new Game {
                Name = request.Name
            };
        }

        public static GameResponse GetGameResponseFromGame(Game game) {
            return new GameResponse {
                Id = game.Id,
                Name = game.Name,
                Tags = TagMapper.GetTagsResponseFromTags(game.Tags)
            };
        }

        public static List<GameResponse> GetGamesResponseFromGames(List<Game> games) {
            List<GameResponse> gamesResponse = new List<GameResponse>();
            if (games != null) {
                games.ForEach(game => { gamesResponse.Add(GetGameResponseFromGame(game)); });
            }
            return gamesResponse;
        }


    }
}
