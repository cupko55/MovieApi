using System;
using System.Collections.Generic;

namespace Seminar.Model
{
    public class Studio : BaseEntity
    {
        public string Name { get; set; }        
        public string Country { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}