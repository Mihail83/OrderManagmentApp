using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagmentApp.BusinessLogic.Models;

namespace OrderManagmentApp.DataLayer.EF.EntityConfiguration
{
    public class Agreement_Order_Configuration : IEntityTypeConfiguration<OrderAgreement>
    {
        public void Configure(EntityTypeBuilder<OrderAgreement> builder)
        {
            builder.HasKey(key => new { key.OrderId, key.AgreementId });
            builder.HasIndex(entity => entity.OrderId).IsUnique();
        }
    }
}
