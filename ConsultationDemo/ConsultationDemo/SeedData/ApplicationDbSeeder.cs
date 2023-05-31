namespace ConsultationDemo.SeedData
{
	using ConsultationDemo.Data;
	using Microsoft.AspNetCore.Identity;
	using System;
	using System.Collections.Generic;

	public class ApplicationDbSeeder
	{
		private readonly IServiceProvider serviceProvider;
		private readonly ApplicationDbContext dbContext;
		private readonly UserManager<IdentityUser> userManager;
		private readonly RoleManager<IdentityRole> roleManager;

		public ApplicationDbSeeder(IServiceProvider serviceProvider, ApplicationDbContext dbContext)
		{
			this.userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
			this.roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
		}

		public async Task SeedDataAsync()
		{
			await SeedUsersAsync();
			await SeedRolesAsync();
			await SeedUserToRolesAsyncAsync();
		}

		private async Task SeedUserToRolesAsyncAsync()
		{
			var user = await this.userManager.FindByNameAsync("Ivan");
			var role = await this.roleManager.FindByNameAsync("Admin");

			var exists = dbContext.UserRoles.Any(x => x.UserId == user.Id && x.RoleId == role.Id);
			if (exists)
			{
				return;
			}

			dbContext.UserRoles.Add(new IdentityUserRole<string>
			{
				RoleId = role.Id,
				UserId = user.Id
			});
			await dbContext.SaveChangesAsync();
		}

		private async Task SeedRolesAsync()
		{
			var role = await this.roleManager.FindByNameAsync("Admin");

			if (role != null)
			{
				return;
			}

			await this.roleManager.CreateAsync(new IdentityRole
			{
				Name = "Admin"
			});
		}

		private async Task SeedUsersAsync()
		{
			var user = await this.userManager.FindByNameAsync("Ivan");

			if (user != null)
			{
				return;
			}

			await this.userManager.CreateAsync(new IdentityUser
			{
				UserName = "Ivan",
				Email = "ivan@abv.bg",
				EmailConfirmed = true,
			}, "ultraSecurePassword");
		}
	}
}
