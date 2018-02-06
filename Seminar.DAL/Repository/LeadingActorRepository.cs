using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Seminar.Model;

namespace Seminar.DAL
{
    public class LeadingActorRepository : ILeadingActorRepository
    {
        private readonly MovieDbContext _context;
        public LeadingActorRepository(MovieDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(LeadingActor o)
        {
            _context.LeadingActor.Add(o);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(LeadingActor o)
        {
            _context.LeadingActor.Update(o);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var model = _context.LeadingActor.FirstOrDefault(x => x.Id == id);
            _context.LeadingActor.Remove(model);
            return await _context.SaveChangesAsync();
        }
        public async Task<LeadingActor> Get(int id)
        {
            return await _context.LeadingActor
                .Include( e => e.MovieLeadingActors)
                .ThenInclude( e => e.Movie)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<ICollection<LeadingActor>> GetList()
        {
            return await _context.LeadingActor.ToListAsync();            
        }
    }
}