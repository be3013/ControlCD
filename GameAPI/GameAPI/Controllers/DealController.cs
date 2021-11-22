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
    public class DealController : Controller
    {
        private readonly ControlGMContext _context;

        public DealController(ControlGMContext context)
        {
            _context = context;
        }

        public IActionResult Index(int Page, string NomeLoja, string NomeJogo)
        {
            if (Page == 0) Page = 1;

            List<Deal> deals = new List<Deal>();

            if (!string.IsNullOrEmpty(NomeLoja))
            {
                deals = _context.Deals.Include(p => p.Store).Where(p => p.Store.NOME.ToUpper().Contains(NomeLoja.ToUpper())).ToList();
            }
            else if (!string.IsNullOrEmpty(NomeJogo)) 
            {
                deals = _context.Deals.Include(p => p.Game).Where(p => p.Game.INTERNAL_NAME.ToUpper().Contains(NomeJogo.ToUpper())).ToList();
            }
            else
            {
                deals = _context.Deals.OrderBy(p => p.ID_DEAL).Include(p => p.Game).Include(p => p.Store).ToList();
            }

            List<Deal> dealsaux = new List<Deal>();

            for (int i = (Page - 1) * 9; i < Page * 9; i++) 
            {
                dealsaux.Add(deals[i]);
            }

            return View(dealsaux);
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