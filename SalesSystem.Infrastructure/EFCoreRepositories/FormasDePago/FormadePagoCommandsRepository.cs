namespace SalesSystem.Infrastructure.EFCoreRepositories.FormasDePago
{
    public class FormadePagoCommandsRepository(
        VentasDbContext context) : IFormadePagoCommandsRepository
    {
        // CREAR FORMA DE PAGO
        public async Task<int> CreateFormadePagoAsync(FormadePagoCreateDto formaPagoDto)
        {
            var formaPago = new FormadePago
            {
                Nombre = formaPagoDto.Nombre,
                Estado = formaPagoDto.Estado,
            };

            context.Add(formaPago);
            await context.SaveChangesAsync();
            return formaPago.Id;
        }

        // ACTUALIZAR FORMA DE PAGO
        public async Task UpdateFormadePagoAsync(FormadePagoCreateDto formaPagoDto)
        {
            var formaPago = await context.Set<FormadePago>().FindAsync(formaPagoDto.Id);

            if (formaPago != null)
            {
                formaPago.Nombre = formaPagoDto.Nombre;
                formaPago.Estado = formaPagoDto.Estado;
                await context.SaveChangesAsync();
            }
        }

        // ELIMINAR FORMA DE PAGO
        public async Task DeleteFormadePagoAsync(int formaPagoId)
        {
            var formaPago = await context.Set<FormadePago>().FindAsync(formaPagoId);

            if (formaPago != null)
            {
                // Eliminado lógico
                formaPago.Estado = false;
                await context.SaveChangesAsync();
            }
        }

        // IMPLEMENTACIÓN DE IUnidadDeTrabajo
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
