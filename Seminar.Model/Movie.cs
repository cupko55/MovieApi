using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seminar.Model
{
    public class Movie : BaseEntity
    {
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(256)]
        public string Description { get; set; }
        
        [Required]
        public decimal Rating { get; set; }
        
        [Required]
        public int NominationsCount { get; set; }
        
        [Required]
        public int NominationsWin { get; set; }        

        [Required] 
        [ForeignKey("Studio")]
        public int StudioId { get; set; }

        public virtual ICollection<MovieLeadingActor> MovieLeadingActors { get; set; }        
        public virtual ICollection<MovieType> MovieTypes { get; set; }

        public virtual Studio Studio { get; set; }
    }
}
