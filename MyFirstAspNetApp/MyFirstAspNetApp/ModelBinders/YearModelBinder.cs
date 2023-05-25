namespace MyFirstAspNetApp.ModelBinders
{
	using Microsoft.AspNetCore.Mvc.ModelBinding;

	public class YearModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			var dateFromRequest = bindingContext.ValueProvider.GetValue("date").FirstOrDefault();
			if (dateFromRequest == null)
			{
				bindingContext.Result = ModelBindingResult.Failed();
			}
			else
			{
				var date = DateTime.Parse(dateFromRequest);
				bindingContext.Result = ModelBindingResult.Success(date.Year);
			}
			return Task.CompletedTask;
		}
	}
}
