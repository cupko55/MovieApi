using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Seminar.Model;

namespace Seminar.DAL
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Movie o)
        {
            _context.Movie.Add(o);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Movie o)
        {
            _context.Movie.Update(o);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var o = _context.Movie.FirstOrDefault(x => x.Id == id);
            _context.Remove(o);
            return await _context.SaveChangesAsync();
        }

        public async Task<Movie> Get(int id)
        {
            return await _context.Movie
                .Include( e => e.MovieLeadingActors)
                .ThenInclude(e => e.LeadingActor)
                .Include(e => e.MovieTypes)
                .ThenInclude(e => e.Type)
                .Include(e => e.Studio)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Movie>> GetList()
        {
            return await _context.Movie.ToListAsync();
        }
    }
}
