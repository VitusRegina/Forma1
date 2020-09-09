using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Forma1.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Forma1.BL;

namespace Forma1.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ICsapatManager csm;

        public HomeController(ICsapatManager am)
        {
            csm = am;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Lista()
        {
            
            IEnumerable<Csapat> csapatList = await csm.ListCsapatok();
            return View(csapatList);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(int CsapatID)
        {
            await csm.DeleteCsapat(CsapatID);
            return RedirectToAction("Lista");
        }

        [Authorize]
        public ViewResult Create() => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(Csapat csapat)
        {
            await csm.CreateCsapat(csapat);
            return RedirectToAction("Lista");
        }

        [Authorize]
        public async Task<IActionResult> Modify(int id)
        {
            Csapat csapat = await csm.GetCsapatOrNull(id);
            return View(csapat);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Modify(int id, Csapat csapat)
        {
            csapat.ID = id;
            await csm.ModifyCsapat(id, csapat);
            return RedirectToAction("Lista");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
