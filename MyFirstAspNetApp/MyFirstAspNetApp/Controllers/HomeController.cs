namespace MyFirstAspNetApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;
	using Microsoft.Extensions.Logging;
	using MyFirstAspNetApp.Filters;
	using MyFirstAspNetApp.Models;
	using MyFirstAspNetApp.Services;
	using MyFirstAspNetApp.ViewModels.Home;
	using System.Diagnostics;

	public class HomeController : Controller
	{
		private readonly IConfiguration configuration;
		private readonly ICountInstancesService countInstancesService;
		private readonly ILogger<HomeController> logger;
		private readonly IMemoryCache memoryCache;

		public HomeController(
			IConfiguration configuration,
			ICountInstancesService countInstancesService,
			ILogger<HomeController> logger,
			IMemoryCache memoryCache)
		{
			this.configuration = configuration;
			this.countInstancesService = countInstancesService;
			this.logger = logger;
			this.memoryCache = memoryCache;
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

		[ServiceFilter(typeof(AddHeaderActionFilterAttribute))]
		[MyAuthorizationFilter]
		[MyExceptionFilter]
		[MyResourceFilter]
		[MyResultFilter]
		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult CacheTest()
		{
			if (!this.memoryCache.TryGetValue<DateTime>("TimeNow", out var value))
			{
				Thread.Sleep(2000);
				value = DateTime.UtcNow;
				this.memoryCache.Set("TimeNow", value, TimeSpan.FromSeconds(10));
			}

			return this.Ok(value);
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