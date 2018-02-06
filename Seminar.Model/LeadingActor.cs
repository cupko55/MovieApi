using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Seminar.Model
{
    public class LeadingActor : BaseEntity
    {
        [Required]
        [StringLength(32)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32)]
        public string LastName { get; set; }
        
        [Required]
        [Range(1, Double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(64)]
        public string Country { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<MovieLeadingActor> MovieLeadingActors { get; set; }        
    }
}
