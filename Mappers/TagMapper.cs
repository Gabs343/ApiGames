using ApiGames.Controllers.Requests;
using ApiGames.Controllers.Responses;
using ApiGames.Models;

namespace ApiGames.Mappers {
    public static class TagMapper {
        public static Tag GetTagFromTagRequest(TagRequest request) {
            return new Tag {
                Name = request.Name
            };
        }

        public static TagResponse GetTagResponseFromTag(Tag tag) {
            return new TagResponse {
                Id = tag.Id,
                Name = tag.Name
            };
        }

        public static List<TagResponse> GetTagsResponseFromTags(List<Tag> tags) {
            List<TagResponse> tagsResponse = new List<TagResponse>();
            if (tags != null) {
                tags.ForEach(tag => { tagsResponse.Add(GetTagResponseFromTag(tag)); });
            }
            return tagsResponse;
        }

    }
}
