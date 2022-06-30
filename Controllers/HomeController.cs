using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.ListaResultados = BD.ListarResultados();
            return View();
        }

        public IActionResult SeleccionarLiga()
        {
            ViewBag.ListaLigas=BD.ListarLigas();
            ViewBag.ListaResultados = BD.ListarResultados();
            return View("Resultados");
        }

        public IActionResult Resultados(int fecha)
        {

            ViewBag.ListaResultados = BD.ListarResultados();
            ViewBag.ListaResultados = BD.ListarResultadosXFecha(fecha);
            return View("Resultados");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
