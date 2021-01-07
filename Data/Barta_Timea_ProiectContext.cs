using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Barta_Timea_Proiect.Store;

namespace Barta_Timea_Proiect.Data
{
    public class Barta_Timea_ProiectContext : DbContext
    {
        public Barta_Timea_ProiectContext (DbContextOptions<Barta_Timea_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Barta_Timea_Proiect.Store.Wine> Wine { get; set; }

        public DbSet<Barta_Timea_Proiect.Store.Brand> Brand { get; set; }

        public DbSet<Barta_Timea_Proiect.Store.Assortment> Assortment { get; set; }
    }
}
