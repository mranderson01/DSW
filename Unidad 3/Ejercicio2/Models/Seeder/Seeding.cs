using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio2.Models.Seeder
{
    public class Seeding
    {
        public void SeedData(ModelBuilder modelBuilder)
        {
            string[] roleNames = { "Admin", "Premium", "Basic" };
            string[] userNames = { "admin@api.com", "premium@api.com", "basic@api.com" };

            //ROLES
            List<IdentityRole> roles = new List<IdentityRole>();
            foreach (var roleName in roleNames)
            {
                var role = new IdentityRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                };
                roles.Add(role);
            }

            //USUARIOS
            List<IdentityUser> users = new List<IdentityUser>();
            foreach (var userName in userNames)
            {
                var user = new IdentityUser
                {
                    UserName = userName,
                    NormalizedUserName = userName.ToUpper(),
                    Email = userName
                };

                //Añadir contraseña hasheada
                var passwordhasher = new PasswordHasher<IdentityUser>();
                user.PasswordHash = passwordhasher.HashPassword(user, "Password*123");
                //Añadir el usuario a la lista de USERS
                users.Add(user);
            }

            modelBuilder.Entity<IdentityUser>().HasData(users);
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            var userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    UserId = users[0].Id,
                    RoleId = roles[0].Id
                },
                new IdentityUserRole<string>
                {
                    UserId = users[1].Id,
                    RoleId = roles[1].Id
                },
                new IdentityUserRole<string>
                {
                    UserId = users[2].Id,
                    RoleId = roles[2].Id
                }
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}

