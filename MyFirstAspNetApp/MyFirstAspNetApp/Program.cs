namespace MyFirstAspNetApp
{
	using Microsoft.AspNetCore.DataProtection.Repositories;
	using MyFirstAspNetApp.Filters;
	using MyFirstAspNetApp.ModelBinders;
	using MyFirstAspNetApp.Services;

	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Host.ConfigureLogging(logging =>
			{
				logging.ClearProviders();
				logging.AddConsole();
			});

			// Add services to the container.
			builder.Services.AddControllersWithViews(configure =>
			{
				configure.ModelBinderProviders.Insert(0, new YearModelBinderProvider());
			});
			builder.Services.AddTransient<IStringManipulation, StringManipulation>();
			builder.Services.AddTransient<IYearsService, YearsService>();
			builder.Services.AddTransient<ICountInstancesService, CountInstancesService>();
			builder.Services.AddTransient<IPositionsService, PositionsService>();
			builder.Services.AddTransient<AddHeaderActionFilterAttribute>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseStatusCodePagesWithRedirects("/Home/HttpError?statusCode={0}");

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}