using Microsoft.EntityFrameworkCore;

namespace Boogle.Models
{
    public partial class BoogledbContext : DbContext
    {
        public BoogledbContext()
        {
        }

        public BoogledbContext(DbContextOptions<BoogledbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthorModel> Autor { get; set; }
        public virtual DbSet<EditorModel> Editor { get; set; }
        public virtual DbSet<BookModel> Libro { get; set; }
        public virtual DbSet<UserModel> Usuario { get; set; }
        public virtual DbSet<UserBook> UsuarioLibro { get; set; }

    }  
}
