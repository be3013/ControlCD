using GameAPI.Data;
using GameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ControlGMContext _context;

        public HomeController(ControlGMContext context)
        {
            _context = context;
        }

        public class HomeViewModel
        {
            public int QtdLojas { get; set; }
            public int QtdPromocoes { get; set; }
            public int QtdJogosPromocoes { get; set; }
            public int QtdJogos { get; set; }
            public List<Deal> Promocoes { get; set; }
        }


        [HttpGet]
        public IActionResult HomeView()
        {
            List<Deal> deals = _context.Deals.OrderBy(p => p.ID_DEAL).Include(p => p.Game).Include(p => p.Store).ToList();

            HomeViewModel aux = new HomeViewModel();
            aux.QtdPromocoes = deals.Count;
            aux.QtdLojas = _context.Stores.Count();
            aux.QtdJogos = _context.Games.Count();
            aux.Promocoes = new List<Deal>();
            for (int i = 0; i < 6; i++)
            {
                aux.Promocoes.Add(deals[i]);
            }

            return View(aux);
        }

        public IActionResult RankStoreView() 
        {

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
