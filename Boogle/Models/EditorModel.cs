using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boogle.Models
{
    public partial class EditorModel
    {
        public EditorModel()
        {
            Libro = new HashSet<BookModel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Editor { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Url { get; set; }

        public virtual ICollection<BookModel> Libro { get; set; }
    }
}
