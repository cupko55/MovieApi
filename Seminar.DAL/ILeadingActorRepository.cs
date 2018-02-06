using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Seminar.Model;

namespace Seminar.DAL
{
    public interface ILeadingActorRepository
    {
        Task<int> Create(LeadingActor o);
        Task<int> Update(LeadingActor o);
        Task<int> Delete(int id);
        Task<LeadingActor> Get(int id);
        Task<ICollection<LeadingActor>> GetList();
    }
}
