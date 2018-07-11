using Microsoft.EntityFrameworkCore;

namespace velocity.Models
{
    public class VelocityContext : DbContext
    {
        public VelocityContext(DbContextOptions<VelocityContext> options)
            : base(options)
        {
        }

        public DbSet<Trader> Trader { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<RoleFeature> RoleFeature { get; set; }
        public DbSet<FormTemplate> FormTemplate { get; set; }
        public DbSet<NamedBankingProductAttribute> NamedBankingProductAttribute { get; set; }
        public DbSet<Mifid> Mifid { get; set; }
        public DbSet<ModelTemplate> ModelTemplate { get; set; }
        public DbSet<ProductTemplate> ProductTemplate { get; set; }
        
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //}
    }
}
