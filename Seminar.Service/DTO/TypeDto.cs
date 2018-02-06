using System;
using System.ComponentModel.DataAnnotations;

namespace Seminar.Service.DTO
{
    public class TypeDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(16)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}