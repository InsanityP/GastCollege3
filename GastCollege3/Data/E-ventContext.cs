using GastCollege3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GastCollege3.Data
{
    public class E_ventContext : DbContext
    {
        public E_ventContext(DbContextOptions<E_ventContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<GastCollege3.Models.Category> Category { get; set; }

        public DbSet<GastCollege3.Models.Aanbieder> Aanbieder { get; set; }

    }
}
