using System.Collections.Generic;
using System.Threading.Tasks;
using Seminar.Service.DTO;

namespace Seminar.Service
{
    public interface IStudioService
    {
        Task<int> Create(StudioDto o);
        Task<int> Update(StudioDto o);
        Task<int> Delete(int id);
        Task<StudioDetailDto> Get(int id);
        Task<ICollection<StudioDto>> GetList();  
    }
}