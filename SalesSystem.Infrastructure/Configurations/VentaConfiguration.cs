 namespace SalesSystem.Infrastructure.Configurations;

internal class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        // Configurar la Llave Primaria
        builder.HasKey(v => v.Id);

        // Propiedades
        builder.Property(v => v.NumeroComprobante)
            .IsRequired()
            .HasMaxLength(20); // máximo 20 caracteres

        builder.Property(v => v.Descuento)
            .HasColumnType("decimal(18,2)");

        builder.Property(v => v.Total)
            .HasColumnType("decimal(18,2)");

        // Relaciones
        builder.HasOne(v => v.Cliente)
            .WithMany() 
            .HasForeignKey(v => v.Id)
            .OnDelete(DeleteBehavior.Restrict); // Evita que si borramos un cliente se borren sus ventas históricas
    }
}
