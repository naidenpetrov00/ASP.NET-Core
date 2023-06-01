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
			this.dbContext = dbContext;
		}

		public async Task SeedDataAsync()
		{
			await SeedUsersAsync();
			await SeedRolesAsync();
			await SeedUserToRolesAsyncAsync();
		}

		private async Task SeedUserToRolesAsyncAsync()
		{
			var user = await this.userManager.FindByNameAsync("NaidenAdmin123");
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
			var user = await this.userManager.FindByNameAsync("NaidenAdmin123");

			if (user != null)
			{
				return;
			}

			var result=await this.userManager.CreateAsync(new IdentityUser
			{
				UserName = "NaidenAdmin123",
				Email = "NaidenAdmin123@abv.bg",
				EmailConfirmed = true,
			}, "ultraSecurePassword");
		}
	}
}
