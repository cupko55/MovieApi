using System;
using System.Collections.Generic;

namespace Seminar.Service.DTO
{
    public class TypeDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MovieDto> Movies { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

    }
}