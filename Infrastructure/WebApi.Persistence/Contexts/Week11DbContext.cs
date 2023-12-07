using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entites;

namespace WebApi.Persistence.Contexts
{
    public class Week11DbContext : DbContext
    {
        public DbSet<BankAccount> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("your-string");
        }
    }
}
