using Microsoft.AspNetCore.Identity;
using Project_Assessment_Bean_Scene_Registration_Application.Models;
using System.Data;

namespace Project_Assessment_Bean_Scene_Registration_Application.Data
{
    public static class IdentitySeeder
    {
        private static readonly string[] Roles =
      [
          "Member",
            "Staff",
            "Manager"
      ];

        private static readonly SeedUser[] Users = [
            new(
                FirstName: "Mary",
                LastName: "Manager",
                Email: "manager@test.com",
                Password: "Password123!",
                Roles: ["Manager", "Staff"]
            ),
            new(
                FirstName: "Steve",
                LastName: "Staff",
                Email: "staff@test.com",
                Password: "Password123!",
                Roles: ["Staff"]
            ),
            new(
                FirstName: "Megan",
                LastName: "Member",
                Email: "member@test.com",
                Password: "Password123!",
                Roles: ["Member"]
            ),
            new(
                FirstName: "Ned",
                LastName: "No-roles",
                Email: "noroles@test.com",
                Password: "Password123!",
                Roles: []
            )
        ];
        /// <summary>
        /// Seed role data
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static async Task SeedRolesAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            // Create each role if it doesn't already exist
            foreach (var role in Roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        /// <summary>
        /// Seed user data
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static async Task SeedUsersAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            // Create each user
            foreach (var seedUser in Users)
            {
                await CreateUserAsync(userManager, seedUser);
            }
        }




        /// <summary>
        /// Creates a user if they do not exist and assign to specified roles.
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="seedUser"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static async Task CreateUserAsync(UserManager<ApplicationUser> userManager, SeedUser seedUser)
        {
            // Check if user already exists
            var user = await userManager.FindByEmailAsync(seedUser.Email);

            if (user == null)
            {
                // Create user if they don't exist
                user = new ApplicationUser
                {
                    UserName = seedUser.Email,
                    Email = seedUser.Email,
                    EmailConfirmed = true,  // Skip email confirmation
                    FirstName = seedUser.FirstName,
                    LastName = seedUser.LastName,
                    PhoneNumber = seedUser.Phone,
                };

                // NOTE: Password is passed in separately as it will be hashed
                var result = await userManager.CreateAsync(user, seedUser.Password);

                // Throw error if user couldn't be added
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create seed user '{seedUser.Email}'.");
                }
            }

            // Assign roles to user
            foreach (var role in seedUser.Roles)
            {
                // Assign role if not already assigned to user
                if (!await userManager.IsInRoleAsync(user, role))
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
        private sealed record SeedUser(
            string FirstName,
            string LastName,
            string Email,
            string Password,
            string[] Roles,
            string? Phone = null
        );


    }
}
