using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seminar.DAL;
using Seminar.Model;
using Seminar.Service.DTO;

namespace Seminar.Service
{
    public class LeadingActorService : ILeadingActorService
    {
        private readonly ILeadingActorRepository _leadingActorRepository;

        public LeadingActorService(ILeadingActorRepository repository)
        {
            _leadingActorRepository = repository;
        }

        public async Task<int> Create(LeadingActorDto o)
        {            
            var model = Map(o);
            return await _leadingActorRepository.Create(model);
        }

        public async Task<int> Update(LeadingActorDto o)
        {
            o.DateUpdated = DateTime.Now;
            var model = Map(o);
            return await _leadingActorRepository.Update(model);
        }

        public async Task<int> Delete(int id)
        {
            return await _leadingActorRepository.Delete(id);
        }

        public async Task<LeadingActorDetailDto> Get(int id)
        {
            var model = await _leadingActorRepository.Get(id);
            
            if(model == null)
            {
                return null;            
            }

            return MapToDetail(model);            
        }

        public async Task<ICollection<LeadingActorDto>> GetList()
        {
            var list = await _leadingActorRepository.GetList();

            if(list != null)
            {
                var dtos = new List<LeadingActorDto>();
                foreach (var item in list)
                {
                    dtos.Add(Map(item));
                }

                return dtos;
            }

            return null;            
        }

        private LeadingActorDto Map(LeadingActor o)
        {
            var dto = new LeadingActorDto{
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Price = o.Price,
                Country = o.Country,
                DateOfBirth = o.DateOfBirth,
                DateCreated = o.DateCreated,
                DateUpdated = o.DateUpdated,                
            };

            return dto;
        }

        private LeadingActor Map(LeadingActorDto o)
        {
            var model = new LeadingActor{
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Price = o.Price,
                Country = o.Country,
                DateOfBirth = o.DateOfBirth,
                DateCreated = o.DateCreated,
                DateUpdated = o.DateUpdated,
            };

            return model;
        }

        private LeadingActorDetailDto MapToDetail(LeadingActor o)
        {
            var dto = new LeadingActorDetailDto{
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Price = o.Price,
                Country = o.Country,
                DateOfBirth = o.DateOfBirth,
                DateCreated = o.DateCreated,
                DateUpdated = o.DateUpdated,
                Movies =  new List<MovieDto>(),
            };

            foreach(var item in o.MovieLeadingActors)
            {
                dto.Movies.Add(new MovieDto{
                    Id = item.Movie.Id,                    
                    Name = item.Movie.Name,
                    Description = item.Movie.Description,
                    Rating = item.Movie.Rating,
                    NominationsCount = item.Movie.NominationsCount,
                    NominationsWin = item.Movie.NominationsWin,
                    DateCreated = o.DateCreated,
                    DateUpdated = o.DateUpdated,
                });
            }
            
            return dto;            
        }
    }
}
