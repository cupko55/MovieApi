using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Seminar.Service.DTO;

namespace Seminar.Service
{
    public interface ILeadingActorService
    {        
        Task<int> Create(LeadingActorDto o);
        Task<int> Update(LeadingActorDto o);
        Task<int> Delete(int id);
        Task<LeadingActorDetailDto> Get(int id);
        Task<ICollection<LeadingActorDto>> GetList();
    }
}
