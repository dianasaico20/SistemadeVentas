using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormadePago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormadePago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumeroComprobante = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FormadePagoId = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImpuestoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_Id",
                        column: x => x.Id,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ventas_FormadePago_FormadePagoId",
                        column: x => x.FormadePagoId,
                        principalTable: "FormadePago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleVentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleVentas_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleVentas_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descripcion", "Estado", "Nombre" },
                values: new object[,]
                {
                    { 1, "Dispositivos electrónicos, smartphones, computadoras y accesorios tecnológicos", true, "Electrónica" },
                    { 2, "Prendas de vestir, calzado y accesorios de moda para toda la familia", true, "Ropa y Moda" },
                    { 3, "Productos alimenticios no perecibles, granos, enlatados y snacks", true, "Alimentos" },
                    { 4, "Bebidas gaseosas, jugos, aguas y bebidas energéticas", true, "Bebidas" },
                    { 5, "Artículos para el hogar, decoración, ropa de cama y utensilios", true, "Hogar" },
                    { 6, "Equipos deportivos, ropa deportiva y accesorios para el ejercicio", true, "Deportes" },
                    { 7, "Juguetes educativos y de entretenimiento para niños de todas las edades", true, "Juguetes" },
                    { 8, "Libros técnicos, novelas, materiales educativos y papelería", true, "Libros y Educación" },
                    { 9, "Herramientas manuales, eléctricas y equipos para construcción y mantenimiento", true, "Herramientas" },
                    { 10, "Productos de belleza, cuidado personal y fragancias", true, "Cosméticos" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Correo", "Direccion", "Estado", "FechaRegistro", "NombreCompleto", "NumeroDocumento", "Telefono", "TipoDocumento" },
                values: new object[,]
                {
                    { 1, "luis.castillo@mail.com", "Av. 10 de Agosto N34-451, Quito", true, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis Castillo", "1723456780", "0991234567", "Cédula" },
                    { 2, "patricia.herrera@mail.com", "Calle Rocafuerte 234, Guayaquil", true, new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patricia Herrera", "0812345679", "0984567890", "Cédula" },
                    { 3, "fernando.mendoza@mail.com", "Calle Bolívar 567, Cuenca", true, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fernando Mendoza", "1345678901", "0975678901", "Cédula" },
                    { 4, "gabriela.rios@mail.com", "Av. Amazonas 890, Quito", true, new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriela Ríos", "0756789012", "0966789012", "Cédula" },
                    { 5, "ventas@comercialguerrero.com", "Calle Chile 123, Quito", true, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comercial Guerrero", "1467890123001", "0957890123", "RUC" },
                    { 6, "valentina.salazar@mail.com", "Av. 9 de Octubre 456, Guayaquil", true, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valentina Salazar", "0978901234", "0948901234", "Cédula" },
                    { 7, null, "Calle Pichincha 789, Ambato", true, new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esteban Naranjo", "1589012345", "0939012345", "Cédula" },
                    { 8, "c.cabrera@mail.com", "Av. Eloy Alfaro 012, Loja", true, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristina Cabrera", "P1234567", "0920123456", "Pasaporte" },
                    { 9, "rodrigo.pacheco@mail.com", "Calle Sucre 345, Ibarra", true, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rodrigo Pacheco", "1701234567", "0911234567", "Cédula" },
                    { 10, null, "Av. Universitaria 678, Santo Domingo", true, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Melissa Delgado", "9999999999", null, "Consumidor Final" }
                });

            migrationBuilder.InsertData(
                table: "FormadePago",
                columns: new[] { "Id", "Estado", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "Efectivo" },
                    { 2, true, "Tarjeta de Crédito" },
                    { 3, true, "Tarjeta de Débito" },
                    { 4, true, "Transferencia Bancaria" },
                    { 5, true, "Pago Móvil" },
                    { 6, true, "Cheque" },
                    { 7, true, "PayPal" },
                    { 8, false, "Criptomoneda" },
                    { 9, true, "Cuotas Sin Interés" },
                    { 10, true, "Vale / Bono" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Contraseña", "Email", "Estado", "FechaRegistro", "Identificacion", "Nombre", "Rol" },
                values: new object[,]
                {
                    { 1, "Sistema", "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", "admin@admin.com", true, new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234567890", "Admin", 1 },
                    { 2, "García", "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", "ana.garcia@ventas.com", true, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0912345671", "Ana", 2 },
                    { 3, "Rodríguez", "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", "carlos.rodriguez@ventas.com", true, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "1723456782", "Carlos", 1 },
                    { 4, "López", "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", "maria.lopez@ventas.com", true, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0823456793", "María", 2 },
                    { 5, "Martínez", "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", "jose.martinez@ventas.com", true, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "1334567894", "José", 2 },
                    { 6, "Sánchez", "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", "laura.sanchez@ventas.com", true, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0745678905", "Laura", 1 },
                    { 7, "Pérez", "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", "roberto.perez@ventas.com", true, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "1456789016", "Roberto", 2 },
                    { 8, "Torres", "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", "diana.torres@ventas.com", true, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0967890127", "Diana", 2 },
                    { 9, "Flores", "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", "miguel.flores@ventas.com", true, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "1578901238", "Miguel", 2 },
                    { 10, "Vargas", "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", "sofia.vargas@ventas.com", true, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "0689012349", "Sofía", 1 },
                    { 11, "Morales", "$2a$12$aSrDuKNoTg8yxrvgJQau3elFMpmYy49Jy2oBawO2hpMpcv5bk9pIy", "andres.morales@ventas.com", true, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "1790123450", "Andrés", 2 }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "Codigo", "Descripcion", "Estado", "ImagenUrl", "Nombre", "PrecioCompra", "PrecioVenta", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "8806094691351", "Teléfono inteligente 6.4\" FHD+, 128GB, 8GB RAM, cámara 50MP", true, "https://images.unsplash.com/photo-1610945415295-d9bbf067e59c?auto=format&fit=crop&w=500&q=60", "Smartphone Samsung Galaxy A54", 320.00m, 450.00m, 25m },
                    { 2, 2, "7890123456781", "Camisa polo de algodón piqué, tallas S-XXL, colores variados", true, "https://images.unsplash.com/photo-1586363104862-3a5e2ab60d99?auto=format&fit=crop&w=500&q=60", "Camisa Polo Sport", 12.00m, 25.00m, 80m },
                    { 3, 3, "7702014003014", "Arroz blanco de grano largo, primera calidad, bolsa de 1 kilogramo", true, "https://images.unsplash.com/photo-1586201375761-83865001e31c?auto=format&fit=crop&w=500&q=60", "Arroz Diana 1kg", 0.90m, 1.50m, 500m },
                    { 4, 4, "5449000000996", "Bebida gaseosa sabor cola, botella PET de 2 litros", true, "https://images.unsplash.com/photo-1622483767028-3f66f32aef97?auto=format&fit=crop&w=500&q=60", "Coca-Cola 2 Litros", 1.10m, 2.00m, 300m },
                    { 5, 5, "8901234567891", "Juego de sábanas 100% algodón 200 hilos, sábana plana, ajustable y 2 fundas", true, "https://images.unsplash.com/photo-1522771739844-6a9f6d5f14af?auto=format&fit=crop&w=500&q=60", "Set de Sábanas Queen Size", 18.00m, 35.00m, 40m },
                    { 6, 6, "4056562008927", "Balón oficial de fútbol talla 5, cuero sintético resistente", true, "https://images.unsplash.com/photo-1614632537190-23e4146777f9?auto=format&fit=crop&w=500&q=60", "Balón de Fútbol Adidas", 16.00m, 30.00m, 60m },
                    { 7, 7, "5702016370768", "Set de construcción con 500 piezas de colores variados para niños +4 años", true, "https://images.unsplash.com/photo-1585366119957-e9730b6d0f60?auto=format&fit=crop&w=500&q=60", "LEGO Classic 500 Piezas", 25.00m, 45.00m, 35m },
                    { 8, 8, "9780132350884", "Libro técnico sobre buenas prácticas de programación y código limpio, edición en inglés", true, "https://images.unsplash.com/photo-1532012197267-da84d127e765?auto=format&fit=crop&w=500&q=60", "Clean Code - Robert C. Martin", 20.00m, 40.00m, 20m },
                    { 9, 9, "3165140571746", "Taladro eléctrico de percusión 600W, incluye juego de brocas y maletín", true, "https://images.unsplash.com/photo-1504148455328-c376907d081c?auto=format&fit=crop&w=500&q=60", "Taladro Percutor Bosch 600W", 52.00m, 85.00m, 15m },
                    { 10, 10, "0773602072453", "Labial mate de larga duración, tono Ruby Woo, presentación 3g", true, "https://images.unsplash.com/photo-1586495777744-4413f21062fa?auto=format&fit=crop&w=500&q=60", "Labial MAC Ruby Woo", 10.00m, 22.00m, 50m }
                });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "Id", "ClienteId", "Descuento", "Estado", "FechaVenta", "FormadePagoId", "ImpuestoTotal", "NumeroComprobante", "SubTotal", "Total", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1, 0m, true, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 54.00m, "COMP-2024-001", 450.00m, 504.00m, 2 },
                    { 2, 2, 0m, true, new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 9.00m, "COMP-2024-002", 75.00m, 84.00m, 4 },
                    { 3, 3, 0m, true, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1.80m, "COMP-2024-003", 15.00m, 16.80m, 5 },
                    { 4, 4, 0m, true, new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2.88m, "COMP-2024-004", 24.00m, 26.88m, 7 },
                    { 5, 5, 5m, true, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 7.80m, "COMP-2024-005", 70.00m, 72.80m, 2 },
                    { 6, 6, 0m, true, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7.20m, "COMP-2024-006", 60.00m, 67.20m, 8 },
                    { 7, 7, 0m, true, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5.40m, "COMP-2024-007", 45.00m, 50.40m, 9 },
                    { 8, 8, 0m, true, new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 9.60m, "COMP-2024-008", 80.00m, 89.60m, 4 },
                    { 9, 9, 0m, true, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 10.20m, "COMP-2024-009", 85.00m, 95.20m, 11 },
                    { 10, 10, 0m, true, new DateTime(2024, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 7.92m, "COMP-2024-010", 66.00m, 73.92m, 7 }
                });

            migrationBuilder.InsertData(
                table: "DetalleVentas",
                columns: new[] { "Id", "Cantidad", "PrecioUnitario", "ProductoId", "SubTotal", "VentaId" },
                values: new object[,]
                {
                    { 1, 1m, 450.00m, 1, 450.00m, 1 },
                    { 2, 3m, 25.00m, 2, 75.00m, 2 },
                    { 3, 10m, 1.50m, 3, 15.00m, 3 },
                    { 4, 12m, 2.00m, 4, 24.00m, 4 },
                    { 5, 2m, 35.00m, 5, 70.00m, 5 },
                    { 6, 2m, 30.00m, 6, 60.00m, 6 },
                    { 7, 1m, 45.00m, 7, 45.00m, 7 },
                    { 8, 2m, 40.00m, 8, 80.00m, 8 },
                    { 9, 1m, 85.00m, 9, 85.00m, 9 },
                    { 10, 3m, 22.00m, 10, 66.00m, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentas_ProductoId",
                table: "DetalleVentas",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentas_VentaId",
                table: "DetalleVentas",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_FormadePagoId",
                table: "Ventas",
                column: "FormadePagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_UsuarioId",
                table: "Ventas",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleVentas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "FormadePago");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
