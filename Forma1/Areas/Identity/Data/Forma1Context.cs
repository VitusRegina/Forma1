using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forma1.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forma1.Data
{
    public class Forma1Context : IdentityDbContext<User>
    {
        public Forma1Context(DbContextOptions<Forma1Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }
}
