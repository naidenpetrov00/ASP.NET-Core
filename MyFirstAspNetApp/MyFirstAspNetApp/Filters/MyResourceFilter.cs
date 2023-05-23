namespace MyFirstAspNetApp.Filters
{
	using Microsoft.AspNetCore.Mvc.Filters;

	public class MyResourceFilter : Attribute, IResourceFilter
	{
		public void OnResourceExecuted(ResourceExecutedContext context)
		{
		}

		public void OnResourceExecuting(ResourceExecutingContext context)
		{
		}
	}
}
