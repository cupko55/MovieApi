using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seminar.Model
{
    public class MovieType
    {
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [ForeignKey("Type")]
        public int TypeId { get; set; }
        public Type Type { get; set; }

        public DateTime DateCreated { get; set; }
    }
}