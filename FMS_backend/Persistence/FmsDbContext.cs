using FMS_backend.Models.FirmF;
using Microsoft.EntityFrameworkCore;

namespace FMS_backend.Persistence
{
    public class FmsDbContext : DbContext
    {

        public FmsDbContext(DbContextOptions<FmsDbContext> options) : base(options) { }

        public DbSet<Firm> Firms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            ModelBuilderForFirm(modelBuilder);
        }

        private void ModelBuilderForFirm(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Firm>()
                .HasDiscriminator<TypeOfCustomer>("TypeOfCoustomer");
        }
    }
}
