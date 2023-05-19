using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstAspNetApp.Models;
using MyFirstAspNetApp.Services;
using MyFirstAspNetApp.ViewModels.Home;
using System.Diagnostics;

namespace MyFirstAspNetApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IConfiguration configuration;
		private readonly ICountInstancesService countInstancesService;
		private readonly ILogger<HomeController> logger;

		public HomeController(IConfiguration configuration, ICountInstancesService countInstancesService, ILogger<HomeController> logger)
		{
			this.configuration = configuration;
			this.countInstancesService = countInstancesService;
			this.logger = logger;
		}

		public IActionResult Index()
		{
			this.logger.LogInformation(this.countInstancesService.Instances.ToString());
			var model = new IndexViewModel
			{
				Year = DateTime.UtcNow.Year,
				UserName = "Naiden",
				Message = this.configuration["YouTube:ApiKey"],
				Names = new string[] { "Pesho", "Ivan" }
			};
			return View(model);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult HttpError(int statusCode)
		{
			return this.View(statusCode);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}