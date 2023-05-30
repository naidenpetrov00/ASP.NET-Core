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
				FirstName = "Naiden",
				LastName = "Petkov",
				University = "Softuni",
				Egn = "0052319061",
				Email = "op@abv.bg",
				DateOfBirth = new DateTime(2000, 1, 1),
				YearsOfExperience = 2
			};
			return this.View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Index(TestInputModel input)
		{
			if (!this.ModelState.IsValid)
			{
				input.AllTypes = this.positionsService.GetAll();
				return this.View(input);
			}

			using (var fileStream = new FileStream(@"C:\Naiden\Softuni\ASP.NET-Core\MyFirstAspNetApp\MyFirstAspNetApp\wwwroot\content\user.pdf", FileMode.Create))
			{
				await input.CV.CopyToAsync(fileStream);
			}
			return this.Redirect("/");
		}

		public IActionResult Download()
		{
			return this.PhysicalFile(@"C:\Naiden\Softuni\ASP.NET-Core\MyFirstAspNetApp\MyFirstAspNetApp\wwwroot\content\user.pdf",
									"application/pdf",
									"Test.pdf");
		}
	}
}
