using System;
using System.ComponentModel.DataAnnotations;

namespace Seminar.Service.DTO
{
    public class StudioDto
    {        
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }        

        [Required]
        public string Country { get; set; }

        public StudioDto()
        {
            
        }

        public StudioDto(int id, string country, string name)
        {
            this.Id = id;
            this.Name = name;
            this.Country = country;
        }
    }
}