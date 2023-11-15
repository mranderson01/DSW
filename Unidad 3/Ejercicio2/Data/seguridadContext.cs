using Ejercicio2.Models.Seeder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio2.Data
{
    public class seguridadContext : IdentityDbContext<IdentityUser>
    {
        public seguridadContext(DbContextOptions<seguridadContext> options)
            :base(options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder) {

            var seeder = new Seeding();
            seeder.SeedData(modelbuilder);
            base.OnModelCreating(modelbuilder);
        }
    }
}
