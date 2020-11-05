using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalApp.Data
{
    public class DentalAppContext : DbContext
    {
        public DentalAppContext(DbContextOptions<DentalAppContext> options)
          : base(options)
        {

        }
        public DbSet<Pacient> Pacient { get; set; }
        public DbSet<Dentist> Dentist { get; set; }
    }
}
