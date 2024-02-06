using Auction.Business.Exceptions.AppUser;
using Auction.Business.Exceptions.Roles;
using Auction.Core.Entities;
using Auction.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Auction.API.Helpers;

public static class Seed
{
    public static IApplicationBuilder UseSeedData(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            using var scope = context.RequestServices.CreateScope();
            var userManager = context.RequestServices.GetRequiredService<UserManager<AppUser>>();
            var roleManager = context.RequestServices.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.Roles.AnyAsync())
                await CreateRolesAsync(roleManager);
            if (await userManager.FindByNameAsync(app.Configuration["Admin:Username"]) == null)
                await CreateAdminUserAsync(userManager, app);

            await next();
        });
        return app;
    }

    static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        foreach (var role in Enum.GetNames(typeof(Roles)))
        {
            var result = await roleManager.CreateAsync(new IdentityRole(role));
            if (!result.Succeeded)
            {
                StringBuilder sb = new();
                foreach (var error in result.Errors)
                {
                    sb.Append(error.Description + " ");
                }
                throw new RoleCreationFailedException(sb.ToString().TrimEnd());
            }
        }
    }
    static async Task CreateAdminUserAsync(UserManager<AppUser> userManager, WebApplication app)
    {
        AppUser user = new AppUser
        {
            UserName = app.Configuration["Admin:Username"],
            Name = app.Configuration["Admin:Name"],
            Surname = app.Configuration["Admin:Surname"],
            Email = app.Configuration["Admin:Email"],
            EmailConfirmed = true,
        };
        var result = await userManager.CreateAsync(user, app.Configuration["Admin:Password"]);
        if (!result.Succeeded)
        {
            if (!result.Succeeded)
            {
                StringBuilder sb = new();
                foreach (var error in result.Errors)
                {
                    sb.Append(error.Description + " ");
                }
                throw new AppUserCreationFailedException(sb.ToString().TrimEnd());
            }
        }
        var roleResult = await userManager.AddToRoleAsync(user, nameof(Roles.Admin));
        if (!roleResult.Succeeded)
        {
            StringBuilder sb = new();
            foreach (var error in result.Errors)
            {
                sb.Append(error.Description + " ");
            }
            throw new RoleAssignFailedException(sb.ToString().TrimEnd());
        }
    }
}
