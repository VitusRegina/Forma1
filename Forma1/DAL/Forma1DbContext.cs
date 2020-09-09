using Forma1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1.DAL
{
    public class Forma1DbContext : DbContext
    {

        public DbSet<Csapat> Csapatok { get; set; }

        public Forma1DbContext(DbContextOptions<Forma1DbContext> options)
           : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Csapat>().ToTable("Csapatok");    
        }
    }
}
