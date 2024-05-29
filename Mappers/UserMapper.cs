using ApiGames.Controllers.Requests;
using ApiGames.Controllers.Responses;
using ApiGames.Models;

namespace ApiGames.Mappers
{
    public static class UserMapper
    {
        public static User GetUserFromUserRequest(UserRequest request) {
            return new User
            {
                Name = request.displayName,
                Mail = request.mail,
                Library = new Library(),
                Wishlist = new Wishlist()
            };
        }

        public static UserResponse GetUserResponseFromUser(User user) {
            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Mail = user.Mail
            };
        }
    }
}
