namespace ApiGames.Models {
    public class Game {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Review> Reviews { get; set; }

        public Game() {
            Tags = new List<Tag>();
            Reviews = new List<Review>();
        }
        public Game(long id, string name) {
            Id = id;
            Name = name;
            Tags = new List<Tag>();
            Reviews = new List<Review>();
        }

        public bool HasTag(long id) {
            return Tags.Any(t => t.Id == id);
        }

        public void AddTag(Tag tag) {
            if (Tags == null) Tags = new List<Tag>();
            if (!HasTag(tag.Id)) {
                Tags.Add(tag);
                tag.AddGame(this);
            }
        }

        public void RemoveTag(Tag tag) {
            if (HasTag(tag.Id)) {
                Tags.Remove(tag);
                tag.RemoveGame(this);
            }
        }
    }
}
