using LDW.Domain.Entities;
using LDW.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDW.WebAPI.Helpers
{
	public class IdentitySeed
	{
		public static async Task InitializeAsync(IServiceProvider serviceProvider)
		{
			var context = serviceProvider.GetRequiredService<UserDbContext>();
			context.Database.EnsureCreated();

			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			string[] roleNames = { "Admin", "User" };

			foreach (var roleName in roleNames)
			{
				var roleExist = await roleManager.RoleExistsAsync(roleName);
				if (!roleExist)
				{
					await roleManager.CreateAsync(new IdentityRole(roleName));
					await context.SaveChangesAsync();
				}
			}

			var userManager = serviceProvider.GetRequiredService<UserManager<UserEntity>>();

			if (!context.Users.Any())
			{
				var superAdmin = new UserEntity()
				{
					Email = "superAdmin@LnuDormWatch.com",
					SecurityStamp = Guid.NewGuid().ToString(),
					UserName = "superAdmin",
				};


				var result = await userManager.CreateAsync(superAdmin, "P@$$word123");
				await userManager.AddToRoleAsync(superAdmin, "Admin");
			}
			await context.SaveChangesAsync();
		}
	}
}
