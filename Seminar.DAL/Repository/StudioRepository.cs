using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Seminar.Model;

namespace Seminar.DAL
{
    public class StudioRepository : IStudioRepository
    {
        private readonly MovieDbContext _context;

        public StudioRepository(MovieDbContext context)
        {
            _context = context;
        }
        
        public async Task<int> Create(Studio o)
        {
            _context.Studio.Add(o);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var o = _context.Studio.FirstOrDefault(x => x.Id == id);
            _context.Remove(o);
            return await _context.SaveChangesAsync();
        }

        public async Task<Studio> Get(int id)
        {
            return await _context.Studio.
                            Include(e => e.Movies).
                            FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Studio>> GetList()
        {
            return await _context.Studio.ToListAsync();
        }

        public async Task<int> Update(Studio o)
        {
            _context.Studio.Update(o);
            return await _context.SaveChangesAsync();
        }
    }
}