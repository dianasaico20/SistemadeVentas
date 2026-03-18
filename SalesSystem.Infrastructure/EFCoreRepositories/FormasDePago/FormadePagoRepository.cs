namespace SalesSystem.Infrastructure.EFCoreRepositories.FormasDePago
{
    public class FormadePagoRepository(
        VentasDbContext context) : IFormadePagoRepository
    {
        // LISTAR TODAS LAS FORMAS DE PAGO
        public async Task<IEnumerable<FormadePagoResponseDto>> GetFormadePagoAllAsync()
        {
            var listaFormasPago = await context.Set<FormadePago>()
                .AsNoTracking()
                .Select(f => new FormadePagoResponseDto
                {
                    Id = f.Id,
                    Nombre = f.Nombre,
                    Estado = f.Estado,
                })
                .ToListAsync();

            return listaFormasPago;
        }

        // LISTAR POR ID
        public async Task<FormadePagoResponseDto> GetFormadePagoByIdAsync(int formaPagoId)
        {
            var formaPago = await context.Set<FormadePago>()
                .AsNoTracking()
                .Where(f => f.Id == formaPagoId)
                .Select(f => new FormadePagoResponseDto
                {
                    Id = f.Id,
                    Nombre = f.Nombre,
                    Estado = f.Estado,
                })
                .FirstOrDefaultAsync();

            return formaPago;
        }
    }
}
