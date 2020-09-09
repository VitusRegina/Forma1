using Forma1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1.DAL
{
    public interface ICsapatRepo
    {
        public Task<IEnumerable<Csapat>> ListCsapatok();
        public Task<Csapat> GetCsapatOrNull(int csapatID);
        public Task DeleteCsapat(int csapatID);
        public Task ModifyCsapat(int csapatID, Csapat modositott);

        public Task CreateCsapat(Csapat uj);
    }
}
