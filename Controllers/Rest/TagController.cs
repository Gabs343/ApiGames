using ApiGames.Controllers.Requests;
using ApiGames.Controllers.Responses;
using ApiGames.Mappers;
using ApiGames.Models;
using ApiGames.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiGames.Controllers.Rest
{
    [ApiController]
    [Route("api/[controller]s")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _service;

        public TagController(ITagService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<TagResponse>> GetTags(){
            List<Tag> tags = new List<Tag>();
            List<TagResponse> response = new List<TagResponse>();

            try { tags =  _service.GetAllTags(); }
            catch (Exception ex){}

            try { response = TagMapper.GetTagsResponseFromTags(tags); }
            catch (Exception ex) { }

            return Ok(response);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagResponse>> GetTag(long id) {
            Tag? tag = null;
            TagResponse? response = null;

            try { tag = await _service.FindById(id); } 
            catch (Exception ex) {
                return NotFound(ex.Message);
            }

            try { response = TagMapper.GetTagResponseFromTag(tag); }
            catch (Exception ex) { }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<TagResponse>> PostTag(TagRequest request) {
            Tag? tag = null;
            TagResponse? response = null;

            try { tag = TagMapper.GetTagFromTagRequest(request); }
            catch (Exception ex) { }

            try { tag = await _service.Save(tag); }
            catch (Exception ex) { return BadRequest(ex.Message); }

            try { response = TagMapper.GetTagResponseFromTag(tag); }
            catch (Exception ex) { }

            return CreatedAtAction(nameof(GetTag), new { id = response.Id }, response);
        }
    }
}
