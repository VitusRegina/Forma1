using Forma1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1.DAL
{
    public class CsapatRepo : ICsapatRepo
    {
        
        readonly DbContextFactory factory;

        public CsapatRepo(DbContextFactory f)
        {
           
            factory = f;
        }
        public async Task CreateCsapat(Csapat uj)
        {

            using var context = factory.CreateContext();
            await context.Csapatok.AddAsync(uj);
            context.SaveChanges();

        }

        public async Task DeleteCsapat(int csapatID)
        {
            using var context = factory.CreateContext();
            var csapat = await context.Csapatok.FindAsync(csapatID);
            context.Csapatok.Remove(csapat);
            context.SaveChanges();
        }

        public async Task<Csapat> GetCsapatOrNull(int csapatID)
        {

            using var context = factory.CreateContext();
            return await context.Csapatok.FindAsync(csapatID);
        }

        public async Task<IEnumerable<Csapat>> ListCsapatok()
        {

            using var context = factory.CreateContext();
            return await context.Csapatok.ToListAsync();


        }

        public async Task ModifyCsapat(int csapatID, Csapat modositott)
        {

            using var context = factory.CreateContext();
            var csapat = await context.Csapatok.FindAsync(csapatID);
            csapat.Nev = modositott.Nev;
            csapat.Alapitas = modositott.Alapitas;
            csapat.Bajnoksagok = modositott.Bajnoksagok;
            csapat.Fizetes = modositott.Fizetes;
            context.SaveChanges();
        }
    }
}
