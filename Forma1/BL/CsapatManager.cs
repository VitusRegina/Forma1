using Forma1.DAL;
using Forma1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1.BL
{
    public class CsapatManager : ICsapatManager
    {
        private readonly ICsapatRepo csapatRepo;
        public CsapatManager(ICsapatRepo csr)
        {
            csapatRepo = csr;
        }
        public async Task<IEnumerable<Csapat>> ListCsapatok() => await csapatRepo.ListCsapatok();

        public async Task<Csapat> GetCsapatOrNull(int csapatID) => await csapatRepo.GetCsapatOrNull(csapatID);

        public async Task DeleteCsapat(int csapatID)
        {
            await csapatRepo.DeleteCsapat(csapatID);  
        }

        public async Task ModifyCsapat(int csapatID, Csapat modositott) => await csapatRepo.ModifyCsapat(csapatID, modositott);

        public async Task CreateCsapat(Csapat uj) => await csapatRepo.CreateCsapat(uj);
    }
}
