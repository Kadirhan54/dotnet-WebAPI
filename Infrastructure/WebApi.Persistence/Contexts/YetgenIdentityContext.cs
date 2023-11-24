using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApi.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApi.Domain.Entites;

namespace WebApi.Persistence.Contexts
{
    public class YetgenIdentityContext : IdentityDbContext<Domain.Identity.User, Role, Guid>
    {
        public YetgenIdentityContext(DbContextOptions<YetgenIdentityContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Error veriyo diye yazdik??
            modelBuilder.Ignore<Student>();
            //modelBuilder.Ignore<Product>();
            //modelBuilder.Ignore<Category>();
            //modelBuilder.Ignore<ProductCategory>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
