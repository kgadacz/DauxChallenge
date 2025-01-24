namespace DauxChallenge.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserInputModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [MinLength(3, ErrorMessage = "El apellido debe tener al menos 3 caracteres.")]
        public required string Apellido { get; set; }
    }
}
