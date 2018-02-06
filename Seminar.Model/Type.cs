using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Seminar.Model
{
    public class Type : BaseEntity
    {
        [Required]
        [StringLength(16)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(128)]
        public string Description { get; set; }

        public virtual ICollection<MovieType> MovieTypes { get; set; }
    }
}
