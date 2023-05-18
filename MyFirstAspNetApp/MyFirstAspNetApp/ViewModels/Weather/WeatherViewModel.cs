using MyFirstAspNetApp.Data.Enums;

namespace MyFirstAspNetApp.ViewModels.Weather
{
    public class WeatherViewModel
	{
		public string Location { get; set; }

		public int Degrees { get; set; }

		public ConditionsType WeatherConditions { get; set; }
	}
}
