using Microsoft.AspNetCore.Mvc;
using SiteVendasConstrucao.Models;
using SiteVendasConstrucao.Uteis;
using System.Diagnostics;

namespace SiteVendasConstrucao.Controllers
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
            DAL dal = new DAL();
            string sql = "INSERT INTO teste (nome) VALUES ('Teste')";
            int linhasAfetadas = dal.ExecutarComando(sql);

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
