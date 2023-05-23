namespace MyFirstAspNetApp.Filters
{
	using Microsoft.AspNetCore.Mvc.Filters;

	public class MyResultFilter : Attribute, IResultFilter
	{
		public void OnResultExecuted(ResultExecutedContext context)
		{
		}

		public void OnResultExecuting(ResultExecutingContext context)
		{
		}
	}
}
