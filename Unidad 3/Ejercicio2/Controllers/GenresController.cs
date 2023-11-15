using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ejercicio2.Data;
using Ejercicio2.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace Ejercicio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenresController : ControllerBase
    {
        private readonly Ejercicio2Context _context;

        public GenresController(Ejercicio2Context context)
        {
            _context = context;
        }

        // GET: api/Genres
        [HttpGet]
        [Authorize(Roles = "Basic,Premium,Admin")]
        public async Task<ActionResult<List<Genre>>> GetGenre()
        {
          if (_context.Genre == null)
          {
              return NotFound();
          }
            var options = new JsonSerializerOptions
            {
                MaxDepth = 6,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            var games=await _context.Genre.Include(juego => juego.Games).ToListAsync();

            var json = JsonSerializer.Serialize(games, options);
            return Content(json, "application/json");
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Basic,Premium,Admin")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
          if (_context.Genre == null)
          {
              return NotFound();
          }
            var genre = await _context.Genre.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            if (id != genre.Id)
            {
                return BadRequest();
            }

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            if (ModelState.IsValid)
            {
                if (_context.Genre == null)
                {
                    return Problem("Entity set 'Ejercicio2Context.Genre'  is null.");
                }

                List<Genre> lista = await _context.Genre.ToListAsync();


                bool existeGenero = lista.Any(g => g.Id == genre.Id || g.Name == genre.Name);

                if (existeGenero)
                {
                    return Conflict("El género ya existe.");
                }
                else
                {
                    _context.Genre.Add(genre);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetGenre", new { id = genre.Id }, genre);
                }
            }            
            return BadRequest(ModelState);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            if (_context.Genre == null)
            {
                return NotFound();
            }
            var genre = await _context.Genre.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.Genre.Remove(genre);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        private bool GenreExists(int id)
        {
            return (_context.Genre?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
