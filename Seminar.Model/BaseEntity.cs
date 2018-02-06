using System;
using System.Collections.Generic;
using System.Text;

namespace Seminar.Model
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
