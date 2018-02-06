using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Seminar.Model;

namespace Seminar.DAL
{
    public interface IMovieRepository
    {
        Task<int> Create(Movie o);
        Task<int> Update(Movie o);
        Task<int> Delete(int id);
        Task<Movie> Get(int id);
        Task<ICollection<Movie>> GetList();
    }
}
