using GameAPI.Data;
using GameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Controllers
{
    public class GameController : Controller
    {
        private readonly ControlGMContext _context;

        public GameController(ControlGMContext context) 
        {
            _context = context;
        }

        public IActionResult Index(string Nome, int Page)
        {
            var listJogos = _context.Games.OrderBy(p => p.ID_GAME).ToList();
            List<Game> pagegames = new List<Game>();

            if (Page == 0) Page = 1;

            if (!string.IsNullOrEmpty(Nome))
            {
                if (listJogos.Count > 0)
                {
                    var filtroLojas = listJogos.Where(p => p.INTERNAL_NAME.ToUpper().Contains(Nome.ToUpper()));

                    if (filtroLojas.ToList().Count > 7)
                    {
                        if (Page <= filtroLojas.ToList().Count % 7)
                        {
                            for (int i = (Page - 1) * 7; i < (Page - 1) * 7 + 7; i++)
                            {
                                pagegames.Add(filtroLojas.ToList()[i]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 7; i++)
                            {
                                pagegames.Add(filtroLojas.ToList()[i]);
                            }
                        }

                        return View(pagegames);
                    }

                    return View(filtroLojas.ToList());
                }
            }

            if (Page <= listJogos.ToList().Count % 7)
            {
                int max = (Page - 1) * 7 + 7;

                if (max > listJogos.Count()) max = listJogos.Count() - 1;

                for (int i = (Page - 1) * 7; i < max; i++)
                {
                    pagegames.Add(listJogos.ToList()[i]);
                }
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    pagegames.Add(listJogos.ToList()[i]);
                }
            }

            return View(pagegames);
        }
    }
}
