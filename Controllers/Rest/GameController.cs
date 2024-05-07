using ApiGames.Controllers.Requests;
using ApiGames.Controllers.Responses;
using ApiGames.Mappers;
using ApiGames.Models;
using ApiGames.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;

namespace ApiGames.Controllers.Rest {
    [ApiController]
    //[Authorize]
    [Route("api/[controller]s")]
    public class GameController : ControllerBase {
        private readonly IGameService _service;

        public GameController(IGameService service) {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<GameResponse>> GetGames() { 
            List<Game> games = new List<Game>();
            List<GameResponse> response = new List<GameResponse>();

            try { games = _service.GetAllGames(); } 
            catch(Exception ex) { }

            try { response = GameMapper.GetGamesResponseFromGames(games); }
            catch(Exception ex) { }

            return Ok(response);
        }

        [HttpGet("{id}")]
        //[RequiredScope("Games.Read")]
        public async Task<ActionResult<GameResponse>> GetGame(long id) {
            Game? game = null;
            GameResponse? response = null;

            try { game = await _service.FindById(id); } 
            catch (Exception ex) {return NotFound(ex.Message);}

            try { response = GameMapper.GetGameResponseFromGame(game); } 
            catch (Exception ex) { }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(GameRequest request) {
            Game? game = null;
            GameResponse? response = null;

            try { game = GameMapper.GetGameFromGameRequest(request); } 
            catch (Exception ex) { }

            try { game = await _service.Save(game); } 
            catch (Exception ex) { return BadRequest(ex.Message); }

            try { response = GameMapper.GetGameResponseFromGame(game); } 
            catch (Exception ex) { }

            return CreatedAtAction(nameof(GetGame), new { id = response.Id }, response);
        }

        [HttpPost("{id}/AddTags")]
        public async Task<ActionResult<Game>> AddTagsForGame(long id, TagsForGameRequest request) {
            Game? game = null;
            GameResponse? response = null;

            try { game = await _service.FindById(id); } 
            catch (Exception ex) { return NotFound(ex.Message); }

            try { game = await _service.AddTagsToGame(game, request.TagsIds); }
            catch (Exception ex) { }

            try { response = GameMapper.GetGameResponseFromGame(game); }
            catch (Exception ex) { }

            return Ok(response);
        }

        [HttpDelete("{id}/RemoveTags")]
        public async Task<ActionResult<Game>> RemoveTagsForGame(long id, TagsForGameRequest request) {
            Game? game = null;
            GameResponse? response = null;

            try { game = await _service.FindById(id); } 
            catch (Exception ex) { return NotFound(ex.Message); }

            try { game = await _service.RemoveTagsToGame(game, request.TagsIds); } 
            catch (Exception ex) { }

            try { response = GameMapper.GetGameResponseFromGame(game); } 
            catch (Exception ex) { }

            return Ok(response);
        }
    }
}
