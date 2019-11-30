using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
