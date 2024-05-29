using ApiGames.Controllers.Requests;
using ApiGames.Controllers.Responses;
using ApiGames.Mappers;
using ApiGames.Models;
using ApiGames.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiGames.Controllers.Rest {
    
    [ApiController]
    [Route("api/[controller]s")]
    public class WishlistController : ControllerBase{
        private readonly IWishlistService _service;
        private readonly ILibraryService _libraryService;

        public WishlistController(IWishlistService service,
                                  ILibraryService libraryService) { 
            _service = service;
            _libraryService = libraryService;
        }

        [HttpPost("{id}/AddGames")]
        public async Task<ActionResult<WishlistResponse>> AddGamesForWishlist(long id, GamesIdsRequest request) { 
            List<long> missingGames = new List<long>();
            Wishlist? wishlist = null;
            WishlistResponse? response = null;

            try { missingGames = await _libraryService.GetMissingGamesIds(id, request.GamesIds); } 
            catch { }

            try { wishlist = await _service.FindById(id); } 
            catch (Exception ex) { return NotFound(ex.Message); }

            try { wishlist = await _service.AddGamesToWishlist(wishlist, missingGames); } 
            catch { }

            try { response = WishlistMapper.GetWishlistResponseFromWishlist(wishlist); }
            catch { }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WishlistResponse>> GetWishlist(long id) {
            Wishlist? wishlist = null;
            WishlistResponse? response = null;

            try { wishlist = await _service.FindById(id); }
            catch (Exception ex) { return NotFound(ex.Message); }

            try { response = WishlistMapper.GetWishlistResponseFromWishlist(wishlist); }
            catch { }

            return Ok(response);
        }

        
    }
}
