using Microsoft.EntityFrameworkCore;
using Api.Domain.Models.Account;
using Api.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Api.Extensions;

namespace Api.Persistance.Contexts
{
    public class OS_Plus_Money_Flow : IdentityDbContext<User>
    {
        public DbSet<CategoriesType> C_Type { get; set; }
        public DbSet<Categories> Categories{ get; set; }
        public DbSet<MoneyFlow> MoneyFlows{ get; set; }
        public OS_Plus_Money_Flow(DbContextOptions<OS_Plus_Money_Flow> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleExtensions());

        }
    }
}