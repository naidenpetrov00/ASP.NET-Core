namespace MyFirstAspNetApp.Services
{
	using Microsoft.AspNetCore.Mvc.Rendering;

	public class PositionsService : IPositionsService
	{
		public IEnumerable<SelectListItem> GetAll()
		{
			return new List<SelectListItem>
			{
				new SelectListItem{Value = "1", Text = "Junior"},
				new SelectListItem{Value = "2", Text = "Regular"},
				new SelectListItem{Value = "3", Text = "Senior"},
			};
		}
	}
}
