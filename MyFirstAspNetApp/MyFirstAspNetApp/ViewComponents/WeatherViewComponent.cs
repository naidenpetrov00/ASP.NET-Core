namespace MyFirstAspNetApp.ViewComponents
{
	using Microsoft.AspNetCore.Mvc;
	using MyFirstAspNetApp.Data.Enums;
	using MyFirstAspNetApp.ViewModels.Weather;

	public class WeatherViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var model = new WeatherViewModel
			{
				Location = "Stara Zagora",
				Degrees = 22,
				WeatherConditions = ConditionsType.Sunshine
			};
			return View(model);
		}
	}
}
