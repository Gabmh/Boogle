using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Boogle.Models
{
    public class RegisterModel
    {

        public const string INVALIDO = "Usuario y/o contraseña inválido";

        public int Usuario_Id { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "La constraseña es obligatoria")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = INVALIDO)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = INVALIDO)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Mail is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Born date is required")]
        [DataType(DataType.Date)]
        public string BornDate { get; set; }

        public Boolean role { get; set; }

        [DataType(DataType.Date)]
        public string CreateDate { get; set; }
    }
}
