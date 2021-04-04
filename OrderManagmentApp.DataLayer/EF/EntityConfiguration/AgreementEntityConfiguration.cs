using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagmentApp.BusinessLogic.Models;

namespace OrderManagmentApp.DataLayer.EF.EntityConfiguration
{
    public class AgreementEntityConfiguration : IEntityTypeConfiguration<Agreement>
    {
        public void Configure(EntityTypeBuilder<Agreement> builder)
        {
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");
            builder
                .Property(agreement => agreement.Sum)
                .HasColumnType("money");
        }
    }
}
