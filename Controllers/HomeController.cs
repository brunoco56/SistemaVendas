using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaVendas.DAL;
using SistemaVendas.Entidades;
using SistemaVendas.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SistemaVendas.Controllers
{
    public class HomeController : Controller
    { 
        // ESTUDAR Conflito de 2 Injeções em um método
        //private readonly ILogger<HomeController> _logger;
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        protected ApplicationDbContext Repositorio;
        public HomeController(ApplicationDbContext repositorio)
        {
            Repositorio = repositorio; 
        }
        
        public IActionResult Index()
        {
            IEnumerable<Categoria> lista = Repositorio.Categoria.ToList();

            return View(lista);
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
