using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Seminar.Model;

namespace Seminar.DAL
{
    public interface ITypeRepository
    {
        Task<int> Create(Model.Type o);
        Task<int> Update(Model.Type o);
        Task<int> Delete(int id);
        Task<Model.Type> Get(int id);
        Task<ICollection<Model.Type>> GetList();
    } 
    
}