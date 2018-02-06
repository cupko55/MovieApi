using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Seminar.DAL
{
    public class TypeRepository : ITypeRepository
    {
        private readonly MovieDbContext _context;

        public TypeRepository(MovieDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Model.Type o)
        {
            _context.Type.Add(o);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(Model.Type o)
        {
            _context.Type.Update(o);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var model = _context.Type.FirstOrDefault(x => x.Id == id);
            _context.Type.Remove(model);
            return await _context.SaveChangesAsync();
        }
        public async Task<Model.Type> Get(int id)
        {
            return await _context.Type
                .Include(e => e.MovieTypes)
                .ThenInclude(e => e.Movie)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<ICollection<Model.Type>> GetList()
        {
            return await _context.Type.ToListAsync();
        }
    }
}