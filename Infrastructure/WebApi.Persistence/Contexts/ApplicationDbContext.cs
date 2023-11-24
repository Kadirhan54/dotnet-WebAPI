using System.Reflection;
using Microsoft.EntityFrameworkCore;

using WebApi.Domain.Entites;
using WebApi.Domain.Identity;

namespace WebApi.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // ?? Error veriyo diye ekledik anlamadim
            modelBuilder.Ignore<Domain.Identity.User>();
            modelBuilder.Ignore<Role>();
            modelBuilder.Ignore<UserSetting>();

            base.OnModelCreating(modelBuilder);
        }


    }
}
