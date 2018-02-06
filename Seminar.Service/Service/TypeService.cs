using System.Threading.Tasks;
using System.Collections.Generic;
using Seminar.Service.DTO;
using Seminar.DAL;
using Seminar.Model;
using System;

namespace Seminar.Service
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;

        public TypeService(ITypeRepository repository)
        {
            _typeRepository = repository;
        }
        
        public async Task<int> Create(TypeDto o)
        {
            var model = Map(o);            
            return await _typeRepository.Create(model);
        }

        public async Task<int> Update(TypeDto o)
        {
            o.DateUpdated = DateTime.Now;
            var model = Map(o);
            return await _typeRepository.Update(model);
        }

        public async Task<int> Delete(int id)
        {
            return await _typeRepository.Delete(id);
        }

        public async Task<TypeDetailDto> Get(int id)
        {
            var model = await _typeRepository.Get(id);
            
            if(model == null)
            {
                return null;            
            }

            return MapToDetail(model);
        }

        public async Task<ICollection<TypeDto>> GetList()
        {
            var list = await _typeRepository.GetList();

            if(list != null)
            {
                var dtos = new List<TypeDto>();
                foreach (var item in list)
                {
                    dtos.Add(Map(item));
                }
                return dtos;
            }

            return null;
        }

        private Model.Type Map(TypeDto o)
        {
            var model = new Model.Type{
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                DateCreated = o.DateCreated,
                DateUpdated = o.DateUpdated                
            };

            return model;
        }

        private TypeDto Map(Model.Type o)
        {
            var dto = new TypeDto{
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                DateCreated = o.DateCreated,
                DateUpdated = o.DateUpdated
            };

            return dto;
        }

        private TypeDetailDto MapToDetail(Model.Type o)
        {
            var dto = new TypeDetailDto{
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                DateCreated = o.DateCreated,
                DateUpdated = o.DateUpdated,
                Movies = new List<MovieDto>(),
            };

            foreach (var item in o.MovieTypes)
            {
                dto.Movies.Add(new MovieDto{
                    Id = item.Movie.Id,                    
                    Name = item.Movie.Name,
                    Description = item.Movie.Description,
                    Rating = item.Movie.Rating,
                    NominationsCount = item.Movie.NominationsCount,
                    NominationsWin = item.Movie.NominationsWin,
                    DateCreated = o.DateCreated,
                    DateUpdated = o.DateUpdated                    
                });
            }

            return dto;
        }
    }
}