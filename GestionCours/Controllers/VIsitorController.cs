using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GestionCours.Controllers
{
    public class VIsitorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}