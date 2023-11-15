using Ejercicio2.Models;
using Ejercicio2.Models.SignUp;
using Ejercicio2.seguridadToken;
using MessagePack.Formatters;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace Ejercicio2.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthController(
            TokenService tokenService,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _tokenService = tokenService;
            _userManager = userManager;           
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegistrerUser registrarUsuario) { 
            //Existe el usuario
            var userExiste = await _userManager.FindByEmailAsync(registrarUsuario.Email);

            if (userExiste != null)
            {
                return StatusCode(
                    StatusCodes.Status403Forbidden,
                    new Response { Status = "Error", Message="El usuario ya existe"}
                );
            }

            //Añadir el usuario en la base de datos

            IdentityUser user = new ()
            {                                
                UserName = registrarUsuario.Username,
                NormalizedUserName = registrarUsuario.Username.ToUpper(),
                Email = registrarUsuario.Email,
                NormalizedEmail = registrarUsuario.Email.ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user,registrarUsuario.Password);

            if (!result.Succeeded) {
                StatusCode(StatusCodes.Status500InternalServerError,
                            new Response { Status = "Error", Message = "El usuario no se pudo crear" });
            }
            //Añadir el rol

            await _userManager.AddToRoleAsync(user, "Basic");

            return StatusCode(StatusCodes.Status201Created,
                            new Response { Status = "Satisfactorio", Message = "Se creo satisfactoriamente el usuario" });

        }

        /*[HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // Lógica para autenticar al usuario
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                // Usuario autenticado correctamente

                // Generar el token
                var token = await _tokenService.GenerateToken(model.UserName);

                // Puedes devolver el token como parte de la respuesta
                return Ok(new { Token = token });
            }
            else
            {
                // Fallo de autenticación
                return Unauthorized();
            }
        }*/
    } 
}
