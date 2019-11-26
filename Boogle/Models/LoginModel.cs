using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Boogle.Models
{
    public class LoginModel
    {

        public const string INVALIDO = "Usuario y/o contraseña inválido";

        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "La constraseña es obligatoria")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = INVALIDO)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
