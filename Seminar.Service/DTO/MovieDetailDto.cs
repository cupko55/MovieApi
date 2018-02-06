using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Seminar.Service.DTO
{
    public class MovieDetailDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [Required]
        [StringLength(512)]
        public string Description { get; set; }

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public int NominationsCount { get; set; }

        [Required]
        public int NominationsWin { get; set; }        
        public List<LeadingActorDto> LeadingActors { get; set; }

        [Required]
        public int[] LeadingActorIDs { get; set; }

        public List<TypeDto> Types { get; set; }

        [Required]
        public int[] TypeIDs { get; set; }

        [Required]
        public int StudioId { get; set; }

        public StudioDto Studio { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}