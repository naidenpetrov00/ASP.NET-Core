namespace MyFirstAspNetApp.ModelBinders
{
	using Microsoft.AspNetCore.Mvc.ModelBinding;

	public class YearModelBinderProvider : IModelBinderProvider
	{
		public IModelBinder? GetBinder(ModelBinderProviderContext context)
		{
			if (context.Metadata?.Name?.ToLower() == "year" &&
				context.Metadata?.ModelType == typeof(int))
			{
				return new YearModelBinder();
			}

			return null;
		}
	}
}
