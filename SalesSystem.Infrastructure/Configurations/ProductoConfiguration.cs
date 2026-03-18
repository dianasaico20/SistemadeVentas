 namespace SalesSystem.Infrastructure.Configurations;

internal class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        // Configurar la Llave Primaria
        builder.HasKey(v => v.Id);

        // Propiedades
        builder.Property(p => p.PrecioVenta).HasColumnType("decimal(18,2)");
        builder.Property(p => p.PrecioCompra).HasColumnType("decimal(18,2)");
        builder.Property(p => p.Stock).HasColumnType("decimal(18,4)");
        builder.Property(p => p.ImagenUrl).HasMaxLength(2048);


    }
}
