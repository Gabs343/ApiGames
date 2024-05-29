using ApiGames.Controllers.Requests;
using ApiGames.Controllers.Responses;
using ApiGames.Mappers;
using ApiGames.Models;
using ApiGames.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiGames.Controllers.Rest {
    [Route("api/Libraries")]
    [ApiController]
    public class LibraryController : ControllerBase {
        private readonly ILibraryService _service;

        public LibraryController(ILibraryService service) {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryResponse>> GetLibrary(long id) {
            Library? library = null;
            LibraryResponse? response = null;

            try { library = await _service.FindById(id); } 
            catch (Exception ex) { return NotFound(ex.Message); }

            try { response = LibraryMapper.GetLibraryResponseFromLibrary(library); } 
            catch (Exception ex) { }

            return Ok(response);
        }

        [HttpPost("{id}/AddGames")]
        public async Task<ActionResult<LibraryResponse>> AddGamesForLibrary(long id, GamesIdsRequest request) {
            Library? library = null;
            LibraryResponse? response = null;

            try { library = await _service.FindById(id); } 
            catch (Exception ex) { return NotFound(ex.Message); }

            try { library = await _service.AddGamesToLibrary(library, request.GamesIds); } 
            catch (Exception ex) { }

            try { response = LibraryMapper.GetLibraryResponseFromLibrary(library); } 
            catch (Exception ex) { }

            return Ok(response);
        }
    }
}
