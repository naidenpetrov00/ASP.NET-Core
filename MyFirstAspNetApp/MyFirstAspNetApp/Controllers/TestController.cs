namespace MyFirstAspNetApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using MyFirstAspNetApp.ViewModels.Test;

	public class TestController : Controller
	{
		public IActionResult Index()
		{
			return this.View();
		}

		[HttpPost]
		public IActionResult Index(TestInputModel input)
		{
			if (!this.ModelState.IsValid)
			{
				return this.Json(ModelState);
			}

			return this.View(input);
		}
	}
}
