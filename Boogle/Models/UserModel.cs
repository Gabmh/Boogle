using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boogle.Models
{
    public class UserModel
    {
        public const string INVALIDO = "Usuario y/o contraseña inválido";

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Usuario_Id { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string Apodo { get; set; }

        [Required(ErrorMessage = "La constraseña es obligatoria")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = INVALIDO)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = INVALIDO)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; }

        [Required(ErrorMessage = "Mail is required")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Born date is required")]
        [DataType(DataType.Date)]
        public string Fecha_nac { get; set; }

        public int rol { get; set; }

        [DataType(DataType.Date)]
        public string Fecha_alta { get; set; }
    }
}
