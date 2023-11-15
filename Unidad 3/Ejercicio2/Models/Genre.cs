using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ejercicio2.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Se requiere el nombre")]
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Se requiere una descripción")]
        [DisplayName("Descriptión")]
        public string Description { get; set; }

        //JUEGOS
        public List<Game>? Games { get; set; }
    }
}
