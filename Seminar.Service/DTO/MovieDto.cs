using System;
using System.Collections.Generic;
using System.Text;

namespace Seminar.Service.DTO
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public int NominationsCount { get; set; }
        public int NominationsWin { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
