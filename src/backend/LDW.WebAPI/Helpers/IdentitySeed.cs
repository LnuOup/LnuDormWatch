using LDW.Domain.Entities;
using LDW.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LDW.WebAPI.Helpers
{
	public class IdentitySeed
	{
		public static async Task InitializeAsync(IServiceProvider serviceProvider)
		{
			var userDbContext = serviceProvider.GetRequiredService<UserDbContext>();
			var applicationDbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			string[] roleNames = { "Admin", "User" };

			foreach (var roleName in roleNames)
			{
				var roleExist = await roleManager.RoleExistsAsync(roleName);
				if (!roleExist)
				{
					await roleManager.CreateAsync(new IdentityRole(roleName));
					await userDbContext.SaveChangesAsync();
				}
			}

			var userManager = serviceProvider.GetRequiredService<UserManager<UserEntity>>();

			if (!userDbContext.Users.Any())
			{
				var superAdmin = new UserEntity()
				{
					Email = "superAdmin@LnuDormWatch.com",
					SecurityStamp = Guid.NewGuid().ToString(),
					UserName = "superAdmin",
				};


				await userManager.CreateAsync(superAdmin, "P@$$word123");
				await userManager.AddToRoleAsync(superAdmin, "Admin");
				await userDbContext.SaveChangesAsync();
			}

			var userIds = userDbContext.Users.Select(u => u.Id).ToList();

			await applicationDbContext.UserRefs.AddRangeAsync(userIds.Select(uid => new UserRefEntity { Id = uid }));
			await applicationDbContext.SaveChangesAsync();
		}
	}
}
