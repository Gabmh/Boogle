using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boogle.Models
{
    public partial class UserBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Usuario_Id { get; set; }
        public int Libro_Id { get; set; }

        public virtual BookModel Libro { get; set; }
        public virtual UserModel Usuario { get; set; }
    }
}
