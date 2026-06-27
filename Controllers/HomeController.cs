using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Assessment_Bean_Scene_Registration_Application.Models;
using System.Diagnostics;

namespace Project_Assessment_Bean_Scene_Registration_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public HomeController(IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index()
        {
            // Load the current homepage image
            string imagePath = "/uploads/homepage.jpg";

            var model = new HomePageImage
            {
                HomeImagePath = imagePath
            };

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult ChangeHomeImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeHomeImage(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                return BadRequest("No file uploaded");

            string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string filePath = Path.Combine(uploadsFolder, "homepage.jpg");

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return Ok(new { message = "Image updated" });
        }

        public IActionResult StaffDashboard()
        {
            return View();
        }

        public IActionResult ManagerDashboard()
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
