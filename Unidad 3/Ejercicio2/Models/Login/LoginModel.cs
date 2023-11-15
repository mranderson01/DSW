using System.ComponentModel.DataAnnotations;

namespace Ejercicio2.Models.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Es requerido el nombre de usuario")]
        public string? Username { get; set; }
        
        [Required(ErrorMessage = "Es requerido la contraseña de usuario")]
        public string? Password { get; set; }
    }
}
