namespace MyFirstAspNetApp.Filters
{
	using Microsoft.AspNetCore.Mvc.Filters;

	public class AddHeaderActionFIlterAttribute : Attribute, IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext context)
		{
			throw new NotImplementedException();
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			throw new NotImplementedException();
		}
	}
}
