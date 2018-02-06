using System;
using System.Collections.Generic;

namespace Seminar.Service.DTO
{
    public class LeadingActorDetailDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Price { get; set; }        
        public string Country { get; set; }        
        public DateTime DateOfBirth { get; set; }
        public List<MovieDto> Movies { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}