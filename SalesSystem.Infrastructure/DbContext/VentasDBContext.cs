using SalesSystem.Application.Enums;

namespace SalesSystem.Infrastructure.DbContextNamespace;

/*
 Add-Migration InitialCreate -StartupProject SalesSystem.API -Project SalesSystem.Infrastructure
Update-Database -StartupProject SalesSystem.API

 
 */

// Heredamos de DbContext y recibimos las opciones (Inyección de Dependencias)
public class VentasDbContext(DbContextOptions<VentasDbContext> options) : DbContext(options)
{
    // Declaración de las tablas 
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    public DbSet<DetalleVenta> DetalleVentas { get; set; }

    // Configuración automática de mapas 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);

        // =====================================================================
        // USUARIOS  (Admin=1 | Vendedor=2)
        // Contraseña de todos los usuarios de prueba: Admin123!
        // =====================================================================
        modelBuilder.Entity<Usuario>().HasData(
            // Usuario administrador principal del sistema
            new Usuario
            {
                Id = 1,
                Email = "admin@admin.com",
                Nombre = "Admin",
                Apellido = "Sistema",
                Identificacion = "1234567890",
                Contraseña = "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy",
                Rol = RolesEnum.Admin,
                Estado = true,
                FechaRegistro = new DateTime(2024, 2, 4)
            },
            new Usuario { Id = 2,  Email = "ana.garcia@ventas.com",      Nombre = "Ana",     Apellido = "García",    Identificacion = "0912345671", Contraseña = "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", Rol = RolesEnum.Vendedor, Estado = true, FechaRegistro = new DateTime(2024, 2, 10) },
            new Usuario { Id = 3,  Email = "carlos.rodriguez@ventas.com", Nombre = "Carlos",  Apellido = "Rodríguez", Identificacion = "1723456782", Contraseña = "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", Rol = RolesEnum.Admin,    Estado = true, FechaRegistro = new DateTime(2024, 2, 12) },
            new Usuario { Id = 4,  Email = "maria.lopez@ventas.com",      Nombre = "María",   Apellido = "López",     Identificacion = "0823456793", Contraseña = "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", Rol = RolesEnum.Vendedor, Estado = true, FechaRegistro = new DateTime(2024, 2, 15) },
            new Usuario { Id = 5,  Email = "jose.martinez@ventas.com",    Nombre = "José",    Apellido = "Martínez",  Identificacion = "1334567894", Contraseña = "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", Rol = RolesEnum.Vendedor, Estado = true, FechaRegistro = new DateTime(2024, 2, 20) },
            new Usuario { Id = 6,  Email = "laura.sanchez@ventas.com",    Nombre = "Laura",   Apellido = "Sánchez",   Identificacion = "0745678905", Contraseña = "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", Rol = RolesEnum.Admin,    Estado = true, FechaRegistro = new DateTime(2024, 3, 1)  },
            new Usuario { Id = 7,  Email = "roberto.perez@ventas.com",    Nombre = "Roberto", Apellido = "Pérez",     Identificacion = "1456789016", Contraseña = "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", Rol = RolesEnum.Vendedor, Estado = true, FechaRegistro = new DateTime(2024, 3, 5)  },
            new Usuario { Id = 8,  Email = "diana.torres@ventas.com",     Nombre = "Diana",   Apellido = "Torres",    Identificacion = "0967890127", Contraseña = "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", Rol = RolesEnum.Vendedor, Estado = true, FechaRegistro = new DateTime(2024, 3, 10) },
            new Usuario { Id = 9,  Email = "miguel.flores@ventas.com",    Nombre = "Miguel",  Apellido = "Flores",    Identificacion = "1578901238", Contraseña = "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", Rol = RolesEnum.Vendedor, Estado = true, FechaRegistro = new DateTime(2024, 3, 15) },
            new Usuario { Id = 10, Email = "sofia.vargas@ventas.com",     Nombre = "Sofía",   Apellido = "Vargas",    Identificacion = "0689012349", Contraseña = "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", Rol = RolesEnum.Admin,    Estado = true, FechaRegistro = new DateTime(2024, 3, 20) },
            new Usuario { Id = 11, Email = "andres.morales@ventas.com",   Nombre = "Andrés",  Apellido = "Morales",   Identificacion = "1790123450", Contraseña = "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", Rol = RolesEnum.Vendedor, Estado = true, FechaRegistro = new DateTime(2024, 3, 25) }
        );

        // =====================================================================
        // CATEGORIAS
        // =====================================================================
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1,  Nombre = "Electrónica",       Descripcion = "Dispositivos electrónicos, smartphones, computadoras y accesorios tecnológicos",        Estado = true  },
            new Categoria { Id = 2,  Nombre = "Ropa y Moda",       Descripcion = "Prendas de vestir, calzado y accesorios de moda para toda la familia",                  Estado = true  },
            new Categoria { Id = 3,  Nombre = "Alimentos",         Descripcion = "Productos alimenticios no perecibles, granos, enlatados y snacks",                      Estado = true  },
            new Categoria { Id = 4,  Nombre = "Bebidas",           Descripcion = "Bebidas gaseosas, jugos, aguas y bebidas energéticas",                                  Estado = true  },
            new Categoria { Id = 5,  Nombre = "Hogar",             Descripcion = "Artículos para el hogar, decoración, ropa de cama y utensilios",                        Estado = true  },
            new Categoria { Id = 6,  Nombre = "Deportes",          Descripcion = "Equipos deportivos, ropa deportiva y accesorios para el ejercicio",                     Estado = true  },
            new Categoria { Id = 7,  Nombre = "Juguetes",          Descripcion = "Juguetes educativos y de entretenimiento para niños de todas las edades",               Estado = true  },
            new Categoria { Id = 8,  Nombre = "Libros y Educación",Descripcion = "Libros técnicos, novelas, materiales educativos y papelería",                           Estado = true  },
            new Categoria { Id = 9,  Nombre = "Herramientas",      Descripcion = "Herramientas manuales, eléctricas y equipos para construcción y mantenimiento",         Estado = true  },
            new Categoria { Id = 10, Nombre = "Cosméticos",        Descripcion = "Productos de belleza, cuidado personal y fragancias",                                   Estado = true  }
        );

        // =====================================================================
        // FORMAS DE PAGO
        // =====================================================================
        modelBuilder.Entity<FormadePago>().HasData(
            new FormadePago { Id = 1,  Nombre = "Efectivo",               Estado = true  },
            new FormadePago { Id = 2,  Nombre = "Tarjeta de Crédito",     Estado = true  },
            new FormadePago { Id = 3,  Nombre = "Tarjeta de Débito",      Estado = true  },
            new FormadePago { Id = 4,  Nombre = "Transferencia Bancaria", Estado = true  },
            new FormadePago { Id = 5,  Nombre = "Pago Móvil",             Estado = true  },
            new FormadePago { Id = 6,  Nombre = "Cheque",                 Estado = true  },
            new FormadePago { Id = 7,  Nombre = "PayPal",                 Estado = true  },
            new FormadePago { Id = 8,  Nombre = "Criptomoneda",           Estado = false },
            new FormadePago { Id = 9,  Nombre = "Cuotas Sin Interés",     Estado = true  },
            new FormadePago { Id = 10, Nombre = "Vale / Bono",            Estado = true  }
        );

        // =====================================================================
        // PRODUCTOS  (CategoriaId 1-10 ← referencia a Categorias)
        // =====================================================================
        modelBuilder.Entity<Producto>().HasData(
       new Producto
       {
           Id = 1,
           Codigo = "8806094691351",
           Nombre = "Smartphone Samsung Galaxy A54",
           Descripcion = "Teléfono inteligente 6.4\" FHD+, 128GB, 8GB RAM, cámara 50MP",
           CategoriaId = 1,
           PrecioVenta = 450.00m,
           PrecioCompra = 320.00m,
           Stock = 25m,
           Estado = true,
           ImagenUrl = "https://images.unsplash.com/photo-1610945415295-d9bbf067e59c?auto=format&fit=crop&w=500&q=60"
       },
       new Producto
       {
           Id = 2,
           Codigo = "7890123456781",
           Nombre = "Camisa Polo Sport",
           Descripcion = "Camisa polo de algodón piqué, tallas S-XXL, colores variados",
           CategoriaId = 2,
           PrecioVenta = 25.00m,
           PrecioCompra = 12.00m,
           Stock = 80m,
           Estado = true,
           ImagenUrl = "https://images.unsplash.com/photo-1586363104862-3a5e2ab60d99?auto=format&fit=crop&w=500&q=60"
       },
       new Producto
       {
           Id = 3,
           Codigo = "7702014003014",
           Nombre = "Arroz Diana 1kg",
           Descripcion = "Arroz blanco de grano largo, primera calidad, bolsa de 1 kilogramo",
           CategoriaId = 3,
           PrecioVenta = 1.50m,
           PrecioCompra = 0.90m,
           Stock = 500m,
           Estado = true,
           ImagenUrl = "https://images.unsplash.com/photo-1586201375761-83865001e31c?auto=format&fit=crop&w=500&q=60"
       },
       new Producto
       {
           Id = 4,
           Codigo = "5449000000996",
           Nombre = "Coca-Cola 2 Litros",
           Descripcion = "Bebida gaseosa sabor cola, botella PET de 2 litros",
           CategoriaId = 4,
           PrecioVenta = 2.00m,
           PrecioCompra = 1.10m,
           Stock = 300m,
           Estado = true,
           ImagenUrl = "https://images.unsplash.com/photo-1622483767028-3f66f32aef97?auto=format&fit=crop&w=500&q=60"
       },
       new Producto
       {
           Id = 5,
           Codigo = "8901234567891",
           Nombre = "Set de Sábanas Queen Size",
           Descripcion = "Juego de sábanas 100% algodón 200 hilos, sábana plana, ajustable y 2 fundas",
           CategoriaId = 5,
           PrecioVenta = 35.00m,
           PrecioCompra = 18.00m,
           Stock = 40m,
           Estado = true,
           ImagenUrl = "https://images.unsplash.com/photo-1522771739844-6a9f6d5f14af?auto=format&fit=crop&w=500&q=60"
       },
       new Producto
       {
           Id = 6,
           Codigo = "4056562008927",
           Nombre = "Balón de Fútbol Adidas",
           Descripcion = "Balón oficial de fútbol talla 5, cuero sintético resistente",
           CategoriaId = 6,
           PrecioVenta = 30.00m,
           PrecioCompra = 16.00m,
           Stock = 60m,
           Estado = true,
           ImagenUrl = "https://images.unsplash.com/photo-1614632537190-23e4146777f9?auto=format&fit=crop&w=500&q=60"
       },
       new Producto
       {
           Id = 7,
           Codigo = "5702016370768",
           Nombre = "LEGO Classic 500 Piezas",
           Descripcion = "Set de construcción con 500 piezas de colores variados para niños +4 años",
           CategoriaId = 7,
           PrecioVenta = 45.00m,
           PrecioCompra = 25.00m,
           Stock = 35m,
           Estado = true,
           ImagenUrl = "https://images.unsplash.com/photo-1585366119957-e9730b6d0f60?auto=format&fit=crop&w=500&q=60"
       },
       new Producto
       {
           Id = 8,
           Codigo = "9780132350884",
           Nombre = "Clean Code - Robert C. Martin",
           Descripcion = "Libro técnico sobre buenas prácticas de programación y código limpio, edición en inglés",
           CategoriaId = 8,
           PrecioVenta = 40.00m,
           PrecioCompra = 20.00m,
           Stock = 20m,
           Estado = true,
           ImagenUrl = "https://images.unsplash.com/photo-1532012197267-da84d127e765?auto=format&fit=crop&w=500&q=60"
       },
       new Producto
       {
           Id = 9,
           Codigo = "3165140571746",
           Nombre = "Taladro Percutor Bosch 600W",
           Descripcion = "Taladro eléctrico de percusión 600W, incluye juego de brocas y maletín",
           CategoriaId = 9,
           PrecioVenta = 85.00m,
           PrecioCompra = 52.00m,
           Stock = 15m,
           Estado = true,
           ImagenUrl = "https://images.unsplash.com/photo-1504148455328-c376907d081c?auto=format&fit=crop&w=500&q=60"
       },
       new Producto
       {
           Id = 10,
           Codigo = "0773602072453",
           Nombre = "Labial MAC Ruby Woo",
           Descripcion = "Labial mate de larga duración, tono Ruby Woo, presentación 3g",
           CategoriaId = 10,
           PrecioVenta = 22.00m,
           PrecioCompra = 10.00m,
           Stock = 50m,
           Estado = true,
           ImagenUrl = "https://images.unsplash.com/photo-1586495777744-4413f21062fa?auto=format&fit=crop&w=500&q=60"
       }
   );

        // =====================================================================
        // CLIENTES  (FechaRegistro = fecha en que se registró en el sistema)
        // =====================================================================
        modelBuilder.Entity<Cliente>().HasData(
            new Cliente { Id = 1,  TipoDocumento = "Cédula",   NumeroDocumento = "1723456780", NombreCompleto = "Luis Castillo",      Correo = "luis.castillo@mail.com",      Telefono = "0991234567", Direccion = "Av. 10 de Agosto N34-451, Quito",     Estado = true, FechaRegistro = new DateTime(2024, 2, 15) },
            new Cliente { Id = 2,  TipoDocumento = "Cédula",   NumeroDocumento = "0812345679", NombreCompleto = "Patricia Herrera",   Correo = "patricia.herrera@mail.com",   Telefono = "0984567890", Direccion = "Calle Rocafuerte 234, Guayaquil",      Estado = true, FechaRegistro = new DateTime(2024, 2, 18) },
            new Cliente { Id = 3,  TipoDocumento = "Cédula",   NumeroDocumento = "1345678901", NombreCompleto = "Fernando Mendoza",   Correo = "fernando.mendoza@mail.com",   Telefono = "0975678901", Direccion = "Calle Bolívar 567, Cuenca",           Estado = true, FechaRegistro = new DateTime(2024, 2, 20) },
            new Cliente { Id = 4,  TipoDocumento = "Cédula",   NumeroDocumento = "0756789012", NombreCompleto = "Gabriela Ríos",       Correo = "gabriela.rios@mail.com",      Telefono = "0966789012", Direccion = "Av. Amazonas 890, Quito",              Estado = true, FechaRegistro = new DateTime(2024, 2, 25) },
            new Cliente { Id = 5,  TipoDocumento = "RUC",      NumeroDocumento = "1467890123001",NombreCompleto = "Comercial Guerrero", Correo = "ventas@comercialguerrero.com", Telefono = "0957890123", Direccion = "Calle Chile 123, Quito",               Estado = true, FechaRegistro = new DateTime(2024, 3, 1)  },
            new Cliente { Id = 6,  TipoDocumento = "Cédula",   NumeroDocumento = "0978901234", NombreCompleto = "Valentina Salazar",  Correo = "valentina.salazar@mail.com",  Telefono = "0948901234", Direccion = "Av. 9 de Octubre 456, Guayaquil",     Estado = true, FechaRegistro = new DateTime(2024, 3, 5)  },
            new Cliente { Id = 7,  TipoDocumento = "Cédula",   NumeroDocumento = "1589012345", NombreCompleto = "Esteban Naranjo",    Correo = null,                          Telefono = "0939012345", Direccion = "Calle Pichincha 789, Ambato",          Estado = true, FechaRegistro = new DateTime(2024, 3, 8)  },
            new Cliente { Id = 8,  TipoDocumento = "Pasaporte",NumeroDocumento = "P1234567",   NombreCompleto = "Cristina Cabrera",   Correo = "c.cabrera@mail.com",          Telefono = "0920123456", Direccion = "Av. Eloy Alfaro 012, Loja",            Estado = true, FechaRegistro = new DateTime(2024, 3, 10) },
            new Cliente { Id = 9,  TipoDocumento = "Cédula",   NumeroDocumento = "1701234567", NombreCompleto = "Rodrigo Pacheco",    Correo = "rodrigo.pacheco@mail.com",    Telefono = "0911234567", Direccion = "Calle Sucre 345, Ibarra",              Estado = true, FechaRegistro = new DateTime(2024, 3, 15) },
            new Cliente { Id = 10, TipoDocumento = "Consumidor Final", NumeroDocumento = "9999999999", NombreCompleto = "Melissa Delgado", Correo = null,                      Telefono = null,         Direccion = "Av. Universitaria 678, Santo Domingo", Estado = true, FechaRegistro = new DateTime(2024, 3, 20) }
        );

        // =====================================================================
        // VENTAS  (IVA = 12%)
        // =====================================================================
        modelBuilder.Entity<Venta>().HasData(
            new Venta { Id = 1,  FechaVenta = new DateTime(2024, 4, 1),  NumeroComprobante = "COMP-2024-001", ClienteId = 1,  UsuarioId = 2,  SubTotal = 450.00m, Descuento = 0m, ImpuestoTotal = 54.00m,  Total = 504.00m, FormadePagoId = 1, Estado = true },
            new Venta { Id = 2,  FechaVenta = new DateTime(2024, 4, 3),  NumeroComprobante = "COMP-2024-002", ClienteId = 2,  UsuarioId = 4,  SubTotal = 75.00m,  Descuento = 0m, ImpuestoTotal = 9.00m,   Total = 84.00m,  FormadePagoId = 2, Estado = true },
            new Venta { Id = 3,  FechaVenta = new DateTime(2024, 4, 5),  NumeroComprobante = "COMP-2024-003", ClienteId = 3,  UsuarioId = 5,  SubTotal = 15.00m,  Descuento = 0m, ImpuestoTotal = 1.80m,   Total = 16.80m,  FormadePagoId = 1, Estado = true },
            new Venta { Id = 4,  FechaVenta = new DateTime(2024, 4, 8),  NumeroComprobante = "COMP-2024-004", ClienteId = 4,  UsuarioId = 7,  SubTotal = 24.00m,  Descuento = 0m, ImpuestoTotal = 2.88m,   Total = 26.88m,  FormadePagoId = 3, Estado = true },
            new Venta { Id = 5,  FechaVenta = new DateTime(2024, 4, 10), NumeroComprobante = "COMP-2024-005", ClienteId = 5,  UsuarioId = 2,  SubTotal = 70.00m,  Descuento = 5m, ImpuestoTotal = 7.80m,   Total = 72.80m,  FormadePagoId = 4, Estado = true },
            new Venta { Id = 6,  FechaVenta = new DateTime(2024, 4, 12), NumeroComprobante = "COMP-2024-006", ClienteId = 6,  UsuarioId = 8,  SubTotal = 60.00m,  Descuento = 0m, ImpuestoTotal = 7.20m,   Total = 67.20m,  FormadePagoId = 1, Estado = true },
            new Venta { Id = 7,  FechaVenta = new DateTime(2024, 4, 15), NumeroComprobante = "COMP-2024-007", ClienteId = 7,  UsuarioId = 9,  SubTotal = 45.00m,  Descuento = 0m, ImpuestoTotal = 5.40m,   Total = 50.40m,  FormadePagoId = 2, Estado = true },
            new Venta { Id = 8,  FechaVenta = new DateTime(2024, 4, 18), NumeroComprobante = "COMP-2024-008", ClienteId = 8,  UsuarioId = 4,  SubTotal = 80.00m,  Descuento = 0m, ImpuestoTotal = 9.60m,   Total = 89.60m,  FormadePagoId = 5, Estado = true },
            new Venta { Id = 9,  FechaVenta = new DateTime(2024, 4, 20), NumeroComprobante = "COMP-2024-009", ClienteId = 9,  UsuarioId = 11, SubTotal = 85.00m,  Descuento = 0m, ImpuestoTotal = 10.20m,  Total = 95.20m,  FormadePagoId = 4, Estado = true },
            new Venta { Id = 10, FechaVenta = new DateTime(2024, 4, 23), NumeroComprobante = "COMP-2024-010", ClienteId = 10, UsuarioId = 7,  SubTotal = 66.00m,  Descuento = 0m, ImpuestoTotal = 7.92m,   Total = 73.92m,  FormadePagoId = 3, Estado = true }
        );

        // =====================================================================
        // DETALLES DE VENTA  (un detalle por venta en los datos iniciales)
        //   SubTotal = PrecioVenta × Cantidad
        // =====================================================================
        modelBuilder.Entity<DetalleVenta>().HasData(
            new DetalleVenta { Id = 1,  VentaId = 1,  ProductoId = 1,  Cantidad = 1m,  PrecioUnitario = 450.00m, SubTotal = 450.00m },
            new DetalleVenta { Id = 2,  VentaId = 2,  ProductoId = 2,  Cantidad = 3m,  PrecioUnitario = 25.00m,  SubTotal = 75.00m  },
            new DetalleVenta { Id = 3,  VentaId = 3,  ProductoId = 3,  Cantidad = 10m, PrecioUnitario = 1.50m,   SubTotal = 15.00m  },
            new DetalleVenta { Id = 4,  VentaId = 4,  ProductoId = 4,  Cantidad = 12m, PrecioUnitario = 2.00m,   SubTotal = 24.00m  },
            new DetalleVenta { Id = 5,  VentaId = 5,  ProductoId = 5,  Cantidad = 2m,  PrecioUnitario = 35.00m,  SubTotal = 70.00m  },
            new DetalleVenta { Id = 6,  VentaId = 6,  ProductoId = 6,  Cantidad = 2m,  PrecioUnitario = 30.00m,  SubTotal = 60.00m  },
            new DetalleVenta { Id = 7,  VentaId = 7,  ProductoId = 7,  Cantidad = 1m,  PrecioUnitario = 45.00m,  SubTotal = 45.00m  },
            new DetalleVenta { Id = 8,  VentaId = 8,  ProductoId = 8,  Cantidad = 2m,  PrecioUnitario = 40.00m,  SubTotal = 80.00m  },
            new DetalleVenta { Id = 9,  VentaId = 9,  ProductoId = 9,  Cantidad = 1m,  PrecioUnitario = 85.00m,  SubTotal = 85.00m  },
            new DetalleVenta { Id = 10, VentaId = 10, ProductoId = 10, Cantidad = 3m,  PrecioUnitario = 22.00m,  SubTotal = 66.00m  }
        );
    }
}