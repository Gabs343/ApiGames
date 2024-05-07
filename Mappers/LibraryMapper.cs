using ApiGames.Controllers.Responses;
using ApiGames.Models;

namespace ApiGames.Mappers
{
    public static class LibraryMapper
    {
        public static LibraryResponse GetLibraryResponseFromLibrary(Library library) {
            return new LibraryResponse
            {
                Id = library.Id,
                Games = GameMapper.GetGamesResponseFromGames(library.Games)
            };
        }
    }
}
