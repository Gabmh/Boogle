using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boogle.Models
{
    public partial class AuthorModel
    {
        public AuthorModel()
        {
            Libro = new HashSet<BookModel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Autor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Fecha_nac { get; set; }

        public virtual ICollection<BookModel> Libro { get; set; }
    }
}
