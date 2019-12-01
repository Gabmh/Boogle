using Microsoft.EntityFrameworkCore;

namespace Boogle.Models
{
    public class ApplicationUserModel:DbContext
    {
        public ApplicationUserModel(DbContextOptions<ApplicationUserModel> options):base(options)
        {

        }



        public DbSet<UserModel> usuario { get; set; }
    }
}
