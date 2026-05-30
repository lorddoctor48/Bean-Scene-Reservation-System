using Microsoft.AspNetCore.Mvc;
using Project_Assessment_Bean_Scene_Registration_Application.Models;
using System.Diagnostics;

namespace Project_Assessment_Bean_Scene_Registration_Application.Controllers
{
    public class HomeController : Controller
    {
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

        public static IActionResult Manager()
        {

        }
    }
}
