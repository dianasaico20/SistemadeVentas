 namespace SalesSystem.Infrastructure.Configurations;

internal class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> builder)
    {
        // Configurar la Llave Primaria
        builder.HasKey(v => v.Id);

        // Propiedades
        builder.Property(d => d.PrecioUnitario).HasColumnType("decimal(18,2)");
        builder.Property(d => d.SubTotal).HasColumnType("decimal(18,2)");

        // Relaciones
        builder.HasOne(v => v.Producto)
            .WithMany() 
            .HasForeignKey(v => v.ProductoId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}
