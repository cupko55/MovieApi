using System.Collections.Generic;

namespace Seminar.Service.DTO
{
    public class StudioDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public string Country { get; set; }        

        public virtual ICollection<MovieDto> Movies { get; set; }
    }
}