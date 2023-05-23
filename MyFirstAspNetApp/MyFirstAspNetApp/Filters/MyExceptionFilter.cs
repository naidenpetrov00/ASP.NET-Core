namespace MyFirstAspNetApp.Filters
{
	using Microsoft.AspNetCore.Mvc.Filters;

	public class MyExceptionFilter : Attribute, IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
		}
	}
}
