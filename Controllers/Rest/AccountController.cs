using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ApiGames.Controllers.Responses;
using System.Net.Http.Headers;
using ApiGames.Controllers.Requests;
using ApiGames.Services;
using ApiGames.Models;
using Microsoft.AspNetCore.Identity;
using ApiGames.Mappers;

namespace ApiGames.Controllers.Rest {
    [ApiController]
    [Route("api/[controller]s")]
    public class AccountController : ControllerBase {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AccountController(IHttpClientFactory httpClientFactory,
                                IConfiguration configuration,
                                IUserService userService) {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _userService = userService;
        }

        [HttpGet("LoginMicrosoft")]
        public async Task<IActionResult> LoginMicrosoft(string code) {
            UserRequest userRequest = null;
            User user = null;
            string accessToken = null;

            try {
                accessToken = await GetAccessTokenFromCode(code);
                userRequest = await GetUser(accessToken);
                user = UserMapper.GetUserFromUserRequest(userRequest);
                bool userExist = await _userService.ExistByMail(user.Mail);
                if (!userExist) {
                    user = await _userService.Save(user);
                } else {
                    user = await _userService.FindByMail(user.Mail);
                }
            } catch (Exception ex) { return BadRequest(); }

            // Return the access token to the client
            return Ok(new { UserId = user.Id, AccessToken = accessToken });
        }

        private async Task<string> GetAccessTokenFromCode(string code) {
            var httpClient = _httpClientFactory.CreateClient();

            string redirectUri = "https://localhost:7222/api/Accounts/LoginMicrosoft";

            var parameters = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("client_id", _configuration["AzureAd:ClientId"]),
                new KeyValuePair<string, string>("client_secret", _configuration["AzureAd:ClientSecret"]),
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("redirect_uri", redirectUri),
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
            });

            var response = await httpClient.PostAsync(_configuration["AzureAd:TokenEndpoint"], parameters);
            var content = await response.Content.ReadAsStringAsync();

            TokenResponse token = JsonSerializer.Deserialize<TokenResponse>(content);

            return token.access_token;
        }

        private async Task<UserRequest> GetUser(string accessToken) {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await httpClient.GetAsync("https://graph.microsoft.com/v1.0/me");
            var content = await response.Content.ReadAsStringAsync();

            UserRequest user = JsonSerializer.Deserialize<UserRequest>(content);

            return user;
        }

    }
}
