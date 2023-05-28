namespace MyFirstAspNetApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using MyFirstAspNetApp.Services;
	using MyFirstAspNetApp.ViewModels.Test;

	public class TestController : Controller
	{
		private readonly IPositionsService positionsService;

		public TestController(IPositionsService positionsService)
		{
			this.positionsService = positionsService;
		}

		public IActionResult Index()
		{
			var model = new TestInputModel
			{
				AllTypes = this.positionsService.GetAll(),
			};
			return this.View(model);
		}

		[HttpPost]
		public IActionResult Index(TestInputModel input)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(input);
			}

			return this.View(input);
		}
	}
}
