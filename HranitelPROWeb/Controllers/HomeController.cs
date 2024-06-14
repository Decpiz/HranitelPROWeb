using HranitelPROWeb.Data;
using HranitelPROWeb.Data.Entities;
using HranitelPROWeb.Data.Repositories;
using HranitelPROWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HranitelPROWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, HranitelDBContext dbContext)

        {
            _logger = logger;
        }

        public IActionResult Index()
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