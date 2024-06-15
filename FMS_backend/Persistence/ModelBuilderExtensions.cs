using FMS_backend.Models.FinancialOperationF;
using FMS_backend.Models.UserF;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS_backend.Persistence
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigureFinancialOperation<TEntity>(this EntityTypeBuilder<TEntity> entity) where TEntity : FinancialOperation
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.DateFrom)
                .IsRequired();

            entity.Property(e => e.DateTo)
                .IsRequired();

            entity.Property(e => e.Income)
                .IsRequired();
        }
        public static void ConfigureUser<TEntity>(this EntityTypeBuilder<TEntity> entity) where TEntity : User
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(12);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.NickName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }

}
