using System.Collections.Generic;
using System.Threading.Tasks;
using PC12410112323100503.Core.Dtos;

namespace PC12410112323100503.Core.Interfaces
{
    public interface IOrdenServicioService
    {
        Task<IEnumerable<OrdenServicioDto>> GetAllAsync();
        Task<OrdenServicioDto?> GetByIdAsync(int id);
        Task<OrdenServicioDto> CreateAsync(OrdenServicioDto dto);
        Task UpdateAsync(int id, OrdenServicioDto dto);
        Task DeleteAsync(int id);
    }
}
