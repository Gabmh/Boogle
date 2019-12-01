using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boogle.Models
{
    public partial class BookModel
    {
        public BookModel()
        {
            UsuarioLibro = new HashSet<UserBook>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Libro_Id { get; set; }
        public string Titulo { get; set; }
        public string Idioma { get; set; }
        public string Desc { get; set; }

        public short Cant_Pag { get; set; }
        public string Generos { get; set; }
        public byte Eliminado { get; set; }
        public int Id_Autor { get; set; }
        public int Id_Editor { get; set; }

        public virtual AuthorModel Id_AutorNavigation { get; set; }
        public virtual EditorModel Id_EditorNavigation { get; set; }
        public virtual ICollection<UserBook> UsuarioLibro { get; set; }
    }
}
