namespace MyFirstAspNetApp.Filters
{
	using Microsoft.AspNetCore.Mvc.Filters;

	public class MyAuthorizationFilter : Attribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{

		}
	}
}
