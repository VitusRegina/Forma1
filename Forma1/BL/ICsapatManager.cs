using Forma1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1.BL
{
    public interface ICsapatManager
    {
        public Task<IEnumerable<Csapat>> ListCsapatok();
        public Task<Csapat> GetCsapatOrNull(int csapatID);
        public Task DeleteCsapat(int csapatID);
        public Task ModifyCsapat(int csapatID, Csapat modositott);

        public Task CreateCsapat(Csapat uj);
    }
}
