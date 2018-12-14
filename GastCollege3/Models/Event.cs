using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GastCollege3.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public bool Full { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int AanbiederId { get; set; }
        public Aanbieder Aanbieder { get; set; }
    }
}
