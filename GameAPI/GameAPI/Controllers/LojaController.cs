using GameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Controllers
{
    public class LojaController : Controller
    {
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
    }
}