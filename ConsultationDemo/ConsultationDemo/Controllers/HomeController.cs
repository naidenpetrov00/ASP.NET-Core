using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using ConsultationDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ConsultationDemo.Services;

namespace ConsultationDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Cloudinary cloudinary;
        private readonly ICloudinaryExtension cloudinaryExtension;

        public HomeController(ILogger<HomeController> logger, Cloudinary cloudinary, ICloudinaryExtension cloudinaryExtension)
        {
            _logger = logger;
            this.cloudinary = cloudinary;
            this.cloudinaryExtension = cloudinaryExtension;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(ICollection<IFormFile> files)
        {
            var result = await this.cloudinaryExtension.Upload(this.cloudinary, files);
            this.ViewBag.Links = result;

            return this.Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}