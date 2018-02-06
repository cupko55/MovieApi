using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Seminar.Service.DTO;

namespace Seminar.Service
{
    public interface ITypeService
    {
        Task<int> Create(TypeDto o);
        Task<int> Update(TypeDto o);
        Task<int> Delete(int id);
        Task<TypeDetailDto> Get(int id);
        Task<ICollection<TypeDto>> GetList();            
    }
}