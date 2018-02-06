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
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository repository)
        {
            _movieRepository = repository;
        }

        public async Task<int> Create(MovieDetailDto o)
        {
            var model = MapFromDetail(o);
            return await _movieRepository.Create(model);
        }

        public async Task<int> Update(MovieDetailDto o)
        {
            o.DateUpdated = DateTime.Now;
            var model = MapFromDetail(o);
            return await _movieRepository.Update(model);
        }

        public async Task<int> Delete(int id)
        {
            return await _movieRepository.Delete(id);
        }

        public async Task<MovieDetailDto> Get(int id)
        {
            var model = await _movieRepository.Get(id); 

            if(model == null)
            {
                return null;            
            }

            return MapToDetail(model);            
        }

        public async Task<ICollection<MovieDto>> GetList()
        {
            var list = await _movieRepository.GetList();

            if(list != null)
            {
                var dtos = new List<MovieDto>();
                foreach (var item in list)
                {
                    dtos.Add(Map(item));
                }
                return dtos;
            }

            return null;
        }               

        private Movie Map(MovieDto o)
        {
            var model = new Movie{
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                Rating = o.Rating,
                NominationsCount = o.NominationsCount,
                NominationsWin = o.NominationsWin,
                DateCreated = o.DateCreated,
                DateUpdated = o.DateUpdated,
            };
            return model;
        }

        private Movie MapFromDetail(MovieDetailDto o)
        {
            var model = new Movie{
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                Rating = o.Rating,
                NominationsCount = o.NominationsCount,
                NominationsWin = o.NominationsWin,
                DateCreated = o.DateCreated,
                DateUpdated = o.DateUpdated,
                MovieLeadingActors = new List<MovieLeadingActor>(),
                MovieTypes = new List<MovieType>(),
                StudioId = o.StudioId
            };
            
            foreach(var item in o.LeadingActorIDs)
            {
                var movieLeadingActor = new MovieLeadingActor();
                movieLeadingActor.LeadingActorId = item;  
                movieLeadingActor.MovieId = o.Id;              
                model.MovieLeadingActors.Add(movieLeadingActor);
            }

            foreach(var item in o.TypeIDs)
            {
                var movieType = new MovieType();
                movieType.TypeId = item;
                movieType.MovieId = o.Id;
                model.MovieTypes.Add(movieType);
            }

            return model;
        }

        private MovieDto Map(Movie o)
        {
            var dto = new MovieDto{
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                Rating = o.Rating,
                NominationsCount = o.NominationsCount,
                NominationsWin = o.NominationsWin,
                DateCreated = o.DateCreated,
                DateUpdated = o.DateUpdated,
            };
            return dto;
        }

        private MovieDetailDto MapToDetail(Movie o)
        {
            var dto = new MovieDetailDto{
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                Rating = o.Rating,
                NominationsCount = o.NominationsCount,
                NominationsWin = o.NominationsWin,
                DateCreated = o.DateCreated,
                DateUpdated = o.DateUpdated,
                LeadingActorIDs = o.MovieLeadingActors.Select(x => x.LeadingActorId).ToArray(),
                TypeIDs = o.MovieTypes.Select(x => x.TypeId).ToArray(),
                LeadingActors =  new List<LeadingActorDto>(),
                Types = new List<TypeDto>(),
                StudioId = o.StudioId,
                Studio = new StudioDto(o.Studio.Id, o.Studio.Country, o.Studio.Name)
            };

            foreach(var item in o.MovieLeadingActors)
            {
                dto.LeadingActors.Add(new LeadingActorDto{
                    Id = item.LeadingActorId,
                    FirstName = item.LeadingActor.FirstName,
                    LastName = item.LeadingActor.LastName,
                    Price = item.LeadingActor.Price,
                    Country = item.LeadingActor.Country,
                    DateOfBirth = item.LeadingActor.DateOfBirth,
                    DateCreated = item.LeadingActor.DateCreated,
                    DateUpdated = item.LeadingActor.DateUpdated,
                });
            }

            foreach(var item in o.MovieTypes)
            {
                dto.Types.Add(new TypeDto{
                    Id = item.TypeId,
                    Name = item.Type.Name,
                    Description = item.Type.Description,
                    DateCreated = o.DateCreated,
                    DateUpdated = o.DateUpdated,
                });
            }

            return dto;
        }
    }
}
