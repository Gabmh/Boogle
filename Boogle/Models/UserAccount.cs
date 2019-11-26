using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Boogle.Models
{
    public class UserAccounts
    {

        public const string INVALIDO = "Usuario y/o contraseña inválido";

        public int Usuario_Id { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "La constraseña es obligatoria")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = INVALIDO)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
