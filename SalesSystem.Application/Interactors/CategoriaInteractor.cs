namespace SalesSystem.Application.Interactors
{
    public class CategoriaInteractor(
        ICategoriaCommandsRepository commands,
        ICategoriaRepository repository) : ICategoriaInputPort
    {
        // CREAR CATEGORIA
        public async Task<BaseResponse> CreateCategoriaAsync(CategoriaCreateDto categoriaDto)
        {
            try
            {
                var id = await commands.CreateCategoriaAsync(categoriaDto);
                return new BaseResponse
                {
                    StatusType = StatusType.SavedTransaction,
                    StatusCode = 201,
                    Message = "Categoria creada satisfactoriamente",
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
                    Message = $"Error al crear categoria: {ex.Message} || Detalle: {detalle}"
                };
            }
        }

        // ACTUALIZAR CATEGORIA
        public async Task<BaseResponse> UpdateCategoriaAsync(CategoriaCreateDto categoriaDto)
        {
            try
            {
                await commands.UpdateCategoriaAsync(categoriaDto);
                return new BaseResponse
                {
                    StatusType = StatusType.UpdateTransaction,
                    StatusCode = 200,
                    Message = "Datos de categoria actualizados satisfactoriamente",
                    Data = categoriaDto.Id
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    StatusType = StatusType.Error,
                    StatusCode = 500,
                    Message = $"Error al actualizar categoria: {ex.Message}"
                };
            }
        }

        // ELIMINAR CATEGORIA
        public async Task<BaseResponse> DeleteCategoriaAsync(int categoriaId)
        {
            try
            {
                await commands.DeleteCategoriaAsync(categoriaId);
                return new BaseResponse
                {
                    StatusType = StatusType.DeletedTransaction,
                    StatusCode = 200,
                    Message = "Categoria eliminada satisfactoriamente",
                    Data = categoriaId
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    StatusType = StatusType.Error,
                    StatusCode = 500,
                    Message = $"Error al eliminar categoria: {ex.Message}"
                };
            }
        }

        // OBTENER POR ID
        public async Task<CategoriaResponseDto> GetCategoriaByIdAsync(int categoriaId)
        {
            return await repository.GetCategoriaByIdAsync(categoriaId);
        }

        // OBTENER TODAS
        public async Task<IEnumerable<CategoriaResponseDto>> GetCategoriaAllAsync()
        {
            return await repository.GetCategoriaAllAsync();
        }
    }
}
