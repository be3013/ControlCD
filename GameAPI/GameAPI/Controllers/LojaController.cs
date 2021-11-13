using GameAPI.Data;
using GameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Controllers
{
    public class LojaController : Controller
    {

        private readonly ControlGMContext _context;

        public LojaController(ControlGMContext context)
        {
            _context = context;
        }

        public List<Loja> lojas = new List<Loja>();

        private void GetDataDB()
        {

            Loja loja = new Loja();
            loja.Nome = "Loja 1";
            loja.PromocaoVigor = -1;
            loja.PromocaoTotal = 30;
            loja.Ativa = true;

            lojas.Add(loja);

            loja = new Loja();
            loja.Nome = "Loja 2";
            loja.PromocaoVigor = 2;
            loja.PromocaoTotal = 30;
            loja.Ativa = true;

            lojas.Add(loja);

            loja = new Loja();
            loja.Nome = "Loja 3";
            loja.PromocaoVigor = 20;
            loja.PromocaoTotal = 30;
            loja.Ativa = true;

            lojas.Add(loja);

            loja = new Loja();
            loja.Nome = "Loja 4";
            loja.PromocaoVigor = 4;
            loja.PromocaoTotal = 30;
            loja.Ativa = true;

            lojas.Add(loja);
        }

        [HttpGet]
        public IActionResult RankLojas() 
        {
            GetDataDB();
            lojas = lojas.OrderByDescending(l => l.PromocaoVigor).ToList();

            
            Debug.WriteLine(lojas[0].PromocaoVigor);
            Debug.WriteLine(lojas[1].PromocaoVigor);
            Debug.WriteLine(lojas[2].PromocaoVigor);

            return View(lojas);
        }
        
        
        public IActionResult Index(String Nome, int Page)
        {
            var listLojas = _context.Stores.OrderBy(p => p.ID_STORE).ToList();
            List<Store> pagestore = new List<Store>();

            if (Page == 0) Page = 1;

            if (!string.IsNullOrEmpty(Nome))
            {
                if(listLojas.Count > 0) 
                {
                    var filtroLojas = listLojas.Where(p => p.NOME.ToUpper().Contains(Nome.ToUpper())).OrderBy(p => p.ID_STORE);

                    if(filtroLojas.ToList().Count > 7) 
                    {
                        if (Page <= filtroLojas.ToList().Count % 7)
                        {
                            for(int i = (Page - 1) * 7; i < (Page - 1) * 7 + 7; i++) 
                            {
                                pagestore.Add(filtroLojas.ToList()[i]);
                            }
                        }
                        else 
                        {
                            for (int i = 0; i < 7; i++)
                            {
                                pagestore.Add(filtroLojas.ToList()[i]);
                            }
                        }

                        foreach (Store store in pagestore)
                        {
                            store.DEALS = new List<Deal>();
                            store.DEALS = _context.Deals.Where(d => d.ID_STORE == store.ID_STORE).ToList();
                            store.GAMES = FillGames(store.DEALS);
                        }

                        return View(pagestore.OrderBy(p => p.ID_STORE));
                    }

                    foreach (Store store in filtroLojas)
                    {
                        store.DEALS = new List<Deal>();
                        store.DEALS = _context.Deals.Where(d => d.ID_STORE == store.ID_STORE).ToList();
                        store.GAMES = FillGames(store.DEALS);
                    }

                    return View(filtroLojas.ToList().OrderBy(p => p.ID_STORE));
                }
            }

            if (Page <= listLojas.ToList().Count % 7)
            {
                int max = (Page - 1) * 7 + 7;

                if (max == 35) max = 32;

                for (int i = (Page - 1) * 7; i < max; i++)
                {
                    pagestore.Add(listLojas.ToList()[i]);
                }
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    pagestore.Add(listLojas.ToList()[i]);
                }
            }

            foreach(Store store in pagestore) 
            {
                store.DEALS = new List<Deal>();
                store.DEALS = _context.Deals.Where(d => d.ID_STORE == store.ID_STORE).ToList();
                store.GAMES = FillGames(store.DEALS);
            }

            return View(pagestore.OrderBy(p => p.ID_STORE));
        }

        private int FillGames(List<Deal> deals) 
        {
            List<int> games = new List<int>();
            foreach(Deal deal in deals) 
            {
                if (!games.Contains(deal.ID_GAME)) 
                {
                    games.Add(deal.ID_GAME);
                }
            }

            return games.Count;
        }
    }
}