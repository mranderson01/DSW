using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ejercicio2.Models;

namespace Ejercicio2.Data
{
    public class Ejercicio2Context : DbContext
    {
        public Ejercicio2Context (DbContextOptions<Ejercicio2Context> options)
            : base(options)
        {
        }

        public DbSet<Game> Game { get; set; } = default!;

        public DbSet<Genre>? Genre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Game>().ToTable("Game",table=>table.ExcludeFromMigrations());
            modelBuilder.Entity<Genre>().ToTable("Genre", table => table.ExcludeFromMigrations());

            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "guerra",
                    Description = "Genero con violencia y sangre"                   
                },
                new Genre
                {
                    Id = 2,
                    Name = "aventura",
                    Description = "Genero con paisajes, varios mundos, mundo abierto."
                },
                new Genre
                {
                    Id = 3,
                    Name = "lucha",
                    Description = "Genero en el cual tiene violencia, puede contener sangre."
                }
            );

            modelBuilder.Entity<Game>().HasData(
                new Game 
                { 
                    Id=1,
                    Name="Terminator 1",
                    Description="Juego de guerra del futuro",
                    genreId = 1                    
                },
                new Game
                {
                    Id = 2,
                    Name = "Terminator 2",
                    Description = "Juego de guerra del futuro",
                    genreId = 1
                },
                new Game
                {
                    Id = 3,
                    Name = "Terminator 3",
                    Description = "Juego de guerra del futuro",
                    genreId = 1
                },
                new Game
                {
                    Id = 4,
                    Name = "Super Mario Bross",
                    Description = "Juego de entretenimiento en varios mundo, el cual se lucha contra monstruos",
                    genreId = 2
                },
                 new Game
                 {
                     Id = 5,
                     Name = "Super Mario Bross",
                     Description = "Juego de entretenimiento en varios mundo, el cual se lucha contra monstruos",
                     genreId = 2
                 },
                  new Game
                  {
                      Id = 6,
                      Name = "Super Mario Bross",
                      Description = "Juego de entretenimiento en varios mundo, el cual se lucha contra monstruos",
                      genreId = 2
                  },
                    new Game
                    {
                        Id = 7,
                        Name = "Tekken 6",
                        Description = "Juego de lucha",
                        genreId = 3
                    },
                    new Game
                    {
                        Id = 8,
                        Name = "Tekken 7",
                        Description = "Juego de lucha",
                        genreId = 3
                    },
                    new Game
                    {
                        Id = 9,
                        Name = "Tekken 8",
                        Description = "Juego de lucha",
                        genreId = 3
                    }                
            ); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
