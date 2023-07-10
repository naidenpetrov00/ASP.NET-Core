namespace Recipes.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using MongoDB.Bson;
	using MongoDB.Driver;
	using Recipes.Models;
	using System.Diagnostics;

	public class HomeController : Controller
	{
		private IMongoCollection<Recipe> recipeCollection;

		public HomeController(IMongoClient client)
		{
			var db = client.GetDatabase("Cooking");
			this.recipeCollection = db.GetCollection<Recipe>("Recipes");
		}

		public IActionResult Index()
		{
			return this.Json(this.recipeCollection);
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