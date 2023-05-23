namespace MyFirstAspNetApp.Filters
{
	using Microsoft.AspNetCore.Mvc.Filters;
	using MyFirstAspNetApp.Services;

	public class AddHeaderActionFilterAttribute : ActionFilterAttribute
	{
		private readonly IYearsService yearsService;

		public AddHeaderActionFilterAttribute(IYearsService yearsService)
		{
			this.yearsService = yearsService;
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			context.HttpContext.Response.Headers.Add("X-Years", string.Join(",", this.yearsService.GetLastYears(5)).ToString());
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
		}
	}
}
