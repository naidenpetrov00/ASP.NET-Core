using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyFirstAspNetApp.Services
{
	public interface IPositionsService
	{
		IEnumerable<SelectListItem> GetAll();
	}
}
