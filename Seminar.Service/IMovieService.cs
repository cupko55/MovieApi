using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Seminar.Service.DTO;

namespace Seminar.Service
{
    public interface IMovieService
    {
        Task<int> Create(MovieDetailDto o);
        Task<int> Update(MovieDetailDto o);
        Task<int> Delete(int id);
        Task<MovieDetailDto> Get(int id);
        Task<ICollection<MovieDto>> GetList();
    }
}
