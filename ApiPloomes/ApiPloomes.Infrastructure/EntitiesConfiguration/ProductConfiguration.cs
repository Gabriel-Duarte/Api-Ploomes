using ApiPloomes.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiPloomes.Infrastructure.EntitiesConfiguration
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(t => t.Id);
			builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
			builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
			builder.Property(p => p.Price).HasPrecision(10, 2);
			builder.Property(p => p.ImageUrl).HasMaxLength(250);
			builder.Property(p => p.Stock).HasDefaultValue(1).IsRequired();
			builder.Property(p => p.RegistrationDate).IsRequired();
			builder.HasOne(e => e.Category).WithMany(e => e.Products)
				.HasForeignKey(e => e.CategoryId);
		}
	}
}
