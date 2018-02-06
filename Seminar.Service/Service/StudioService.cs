using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Seminar.DAL;
using Seminar.Model;
using Seminar.Service.DTO;

namespace Seminar.Service
{
    public class StudioService : IStudioService
    {
        private readonly IStudioRepository _studioRepository;

        public StudioService(IStudioRepository repository)
        {
            _studioRepository = repository;
        }

        public async Task<int> Create(StudioDto o)
        {
            var model = Map(o);
            return await _studioRepository.Create(model);   
        }

        public async Task<int> Update(StudioDto o)
        {
            var model = Map(o);
            model.DateUpdated = DateTime.Now;
            return await _studioRepository.Update(model);
        }

        public async Task<int> Delete(int id)
        {
            return await _studioRepository.Delete(id);
        }

        public async Task<StudioDetailDto> Get(int id)
        {
            var model = await _studioRepository.Get(id);

            if(model == null)
            {
                return null;            
            }

            return MapToDetail(model);
        }

        public async Task<ICollection<StudioDto>> GetList()
        {
            var list = await _studioRepository.GetList();
            if(list != null)
            {                            var dtos = new List<StudioDto>();
                foreach (var item in list)
                {
                    dtos.Add(Map(item));
                }
                return dtos;
            }
            
            return null;
        }

        private Studio Map(StudioDto o)
        {
            var model = new Studio{
                Id = o.Id,
                Name = o.Name,
                Country = o.Country,                
            };

            return model;
        }

        private StudioDto Map(Studio o)
        {
            var dto = new StudioDto{
                Id = o.Id,
                Name = o.Name,
                Country = o.Country,                
            };

            return dto;
        }

        private StudioDetailDto MapToDetail(Studio o)
        {
            var dto = new StudioDetailDto{
                Id = o.Id,
                Name = o.Name,
                Country = o.Country,                
                Movies = new List<MovieDto>(),                
            };

            foreach(var item in o.Movies)
            {
                dto.Movies.Add(new MovieDto{
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Rating = item.Rating,
                    NominationsCount = item.NominationsCount,
                    NominationsWin = item.NominationsWin,                    
                    DateCreated = item.DateCreated,
                    DateUpdated = item.DateUpdated,
                });
            }

            return dto;
        }
    }
}