namespace SalesSystem.Application.Interactors
{
    public class ProductoInteractor(
        IProductoCommandsRepository commands,
        IProductoRepository repository) : IProductoInputPort
    {
        // CREAR PRODUCTO
        public async Task<BaseResponse> CreateProductoAsync(ProductoCreateDto productoDto)
        {
            try
            {
                var id = await commands.CreateProductoAsync(productoDto);
                return new BaseResponse
                {
                    StatusType = StatusType.SavedTransaction,
                    StatusCode = 201,
                    Message = "Producto creado satisfactoriamente",
                    Data = id
                };
            }
            catch (Exception ex)
            {
                var detalle = ex.InnerException?.Message ?? "Sin detalles";
                return new BaseResponse
                {
                    StatusType = StatusType.Error,
                    StatusCode = 500,
                    Message = $"Error al crear producto: {ex.Message} || Detalle: {detalle}"
                };
            }
        }

        // ACTUALIZAR PRODUCTO
        public async Task<BaseResponse> UpdateProductoAsync(ProductoCreateDto productoDto)
        {
            try
            {
                await commands.UpdateProductoAsync(productoDto);
                return new BaseResponse
                {
                    StatusType = StatusType.UpdateTransaction,
                    StatusCode = 200,
                    Message = "Datos de producto actualizados satisfactoriamente",
                    Data = productoDto.Id
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    StatusType = StatusType.Error,
                    StatusCode = 500,
                    Message = $"Error al actualizar producto: {ex.Message}"
                };
            }
        }

        // ELIMINAR PRODUCTO
        public async Task<BaseResponse> DeleteProductoAsync(int productoId)
        {
            try
            {
                await commands.DeleteProductoAsync(productoId);
                return new BaseResponse
                {
                    StatusType = StatusType.DeletedTransaction,
                    StatusCode = 200,
                    Message = "Producto eliminado satisfactoriamente",
                    Data = productoId
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    StatusType = StatusType.Error,
                    StatusCode = 500,
                    Message = $"Error al eliminar producto: {ex.Message}"
                };
            }
        }

        // OBTENER POR ID
        public async Task<ProductoResponseDto> GetProductoByIdAsync(int productoId)
        {
            return await repository.GetProductoByIdAsync(productoId);
        }

        // OBTENER TODOS
        public async Task<IEnumerable<ProductoResponseDto>> GetProductoAllAsync()
        {
            return await repository.GetProductoAllAsync();
        }

        // OBTENER POR CATEGORIA
        public async Task<IEnumerable<ProductoResponseDto>> GetProductoByCategoriaIdAsync(int categoriaId)
        {
            return await repository.GetProductoByCategoriaIdAsync(categoriaId);
        }
    }
}
