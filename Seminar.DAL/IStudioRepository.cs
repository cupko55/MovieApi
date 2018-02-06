using System.Collections.Generic;
using System.Threading.Tasks;
using Seminar.Model;

namespace Seminar.DAL
{
    public interface IStudioRepository
    {
        Task<int> Create(Studio o);
        Task<int> Update(Studio o);
        Task<int> Delete(int id);
        Task<Studio> Get(int id);
        Task<ICollection<Studio>> GetList();
    }
}