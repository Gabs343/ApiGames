using ApiGames.Data;
using ApiGames.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGames.Repositories {
    public class TagRepository : ITagRepository {
        private readonly MyContext _context;

        public TagRepository(MyContext context) {
            _context = context;
        }

        public async Task<Tag?> FindById(long id) {
            return await _context.tags.FindAsync(id);
        }

        public List<Tag> FindByIds(List<long> ids) {
            return _context.tags.Where(tgs => ids.Contains(tgs.Id))
                                .ToList();
        }

        public List<Tag> GetAll() {
            return _context.tags.ToList();
        }

        public void Insert(Tag tag) {
            _context.tags.Add(tag);
        }

        public async Task Save() {
            await _context.SaveChangesAsync();
        }
    }
}
