namespace MyFirstAspNetApp.ViewComponents
{
	using Microsoft.AspNetCore.Mvc;
	using MyFirstAspNetApp.Services;
	using MyFirstAspNetApp.ViewModels.NavBar;

	public class NavBarViewComponent : ViewComponent
	{
		private readonly IYearsService yearsService;

		public NavBarViewComponent(IYearsService yearsService)
		{
			this.yearsService = yearsService;
		}

		public IViewComponentResult Invoke()
		{
			var viewModel = new NavBarViewModel();
			viewModel.Years = yearsService.GetLastYears(5);
			return this.View(viewModel);
		}
	}
}
