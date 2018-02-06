using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Seminar.Service.DTO
{
    public class LeadingActorDto
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(32)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(32)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [Range(1, Double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(64)]
        public string Country { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
