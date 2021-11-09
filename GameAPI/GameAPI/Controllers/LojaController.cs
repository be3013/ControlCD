using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Controllers
{
    public class LojaController : Controller
    {
        public IActionResult Index(String Nome)
        {
            if (!string.IsNullOrEmpty(Nome))
            {

            }

            return View();
        }
    }
}
