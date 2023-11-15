using System.ComponentModel.DataAnnotations;

namespace Ejercicio2.Models.SignUp
{
    public class RegistrerUser
    {        
        [Required(ErrorMessage = "Es requerido el correo de usuario")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Es requerido la contraseña de usuario")]
        public string? Password { get; set; }

    }
}
