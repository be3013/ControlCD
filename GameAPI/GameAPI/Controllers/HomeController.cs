using GameAPI.Models;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public class HomeViewModel
        {
            public int QtdLojas { get; set; }
            public int QtdPromocoes { get; set; }
            public int QtdJogosPromocoes { get; set; }
            public int QtdJogos { get; set; }
            public List<Promocao> Promocoes { get; set; }
        }


        private HomeViewModel GetDataDB()
        {
            //Dados mocados
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.QtdJogos = 10;
            homeViewModel.QtdJogosPromocoes = 10;
            homeViewModel.QtdLojas = 10;

            Promocao promocao = new Promocao();
            promocao.Nome = "Starfield";
            promocao.Descricao = "RPG espacial da Bethesda";
            promocao.ValorDesconto = 250;
            promocao.ValorOriginal = 300;

            Promocao promocao2 = new Promocao();
            promocao2.Nome = "Fallout";
            promocao2.Descricao = "RPG pós-apocaliptico da Bethesda";
            promocao2.ValorDesconto = 250;
            promocao2.ValorOriginal = 350;

            Promocao promocao3 = new Promocao();
            promocao3.Nome = "TES";
            promocao3.Descricao = "RPG medieval da Bethesda";
            promocao3.ValorDesconto = 250;
            promocao3.ValorOriginal = 350;

            Promocao promocao4 = new Promocao();
            promocao4.Nome = "DOM";
            promocao4.Descricao = "Boomer Shooter da ID Software";
            promocao4.ValorDesconto = 0;
            promocao4.ValorOriginal = 0;

            Promocao promocao5 = new Promocao();
            promocao5.Nome = "DOM";
            promocao5.Descricao = "Boomer Shooter da ID Software";
            promocao5.ValorDesconto = 0;
            promocao5.ValorOriginal = 0;

            Promocao promocao6 = new Promocao();
            promocao6.Nome = "DOM";
            promocao6.Descricao = "Boomer Shooter da ID Software";
            promocao6.ValorDesconto = 0;
            promocao6.ValorOriginal = 0;

            Promocao promocao7 = new Promocao();
            promocao7.Nome = "DOM";
            promocao7.Descricao = "Boomer Shooter da ID Software";
            promocao7.ValorDesconto = 0;
            promocao7.ValorOriginal = 0;

            homeViewModel.Promocoes = new List<Promocao>();
            homeViewModel.Promocoes.Add(promocao);
            homeViewModel.Promocoes.Add(promocao2);
            homeViewModel.Promocoes.Add(promocao3);
            homeViewModel.Promocoes.Add(promocao4);
            homeViewModel.Promocoes.Add(promocao5);
            homeViewModel.Promocoes.Add(promocao6);
            homeViewModel.Promocoes.Add(promocao7);




            homeViewModel.Promocoes.OrderByDescending(p => p.ValorDesconto);
            return homeViewModel;
        }

        [HttpGet]
        public IActionResult HomeView(){
            
            return View(GetDataDB());
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
