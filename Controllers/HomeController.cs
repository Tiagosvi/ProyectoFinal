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
            return View();
        }




        public IActionResult SeleccionarLiga(int liga = 0, int fecha=0)
        {
            //si viene liga y no fecha solo carga combo de fechas 
            ViewBag.ListaLigas = BD.ListarLigas();
            ViewBag.LigaSeleccionada = liga;
            if(liga > 0){
                ViewBag.ListaFechas = BD.ListarFechas(liga);
            }
            if(liga>0 && fecha>0)
            {
                ViewBag.FechaSeleccionada=fecha;
                ViewBag.ListaResultados = BD.ListaResultados(liga, fecha);
            }

            return View("Resultados");
        }

       public IActionResult CargaResultados(int liga = 0, int fecha=0)
        {
            ViewBag.ListaLigas = BD.ListarLigas();
            ViewBag.LigaSeleccionada = liga;
            
            if(liga > 0){
                ViewBag.ListaFechas = BD.ListarFechas(liga);
            }
            if(liga>0 && fecha>0)
            {
                ViewBag.FechaSeleccionada=fecha;
                ViewBag.ListaEquipos = BD.ListarEquipos(liga);                
            }
            return View("CargarResultados");
        }

        [HttpPost]
        public IActionResult GuardarResultado(int IdFecha, string Equipo1, string Equipo2, int Goles1, int Goles2)
        {
            ResultadosModel Resul=new ResultadosModel(IdFecha, Equipo1, Equipo2, Goles1, Goles2);
            BD.AgregarResultado(Resul);
            return RedirectToAction("SeleccionarLiga");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

