using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seminar.Model
{
    public class MovieLeadingActor
    {
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        
        [ForeignKey("LeadingActor")]
        public int LeadingActorId { get; set; }
        public LeadingActor LeadingActor { get; set; }
        public DateTime DateCreated { get; set; }
        

    }
}