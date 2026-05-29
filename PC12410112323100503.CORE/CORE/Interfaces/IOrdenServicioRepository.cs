using System.Collections.Generic;
using System.Threading.Tasks;
using PC12410112323100503.Entidades;

namespace PC12410112323100503.Core.Interfaces
{
    public interface IOrdenServicioRepository
    {
        Task<IEnumerable<OrdenServicio>> GetAllAsync();
        Task<OrdenServicio?> GetByIdAsync(int id);
        Task<OrdenServicio> CreateAsync(OrdenServicio ordenServicio);
        Task UpdateAsync(OrdenServicio ordenServicio);
        Task DeleteAsync(int id);
        Task<bool> ExistsVehiculoAsync(int vehiculoId);
        Task<bool> ExistsTipoServicioAsync(int tipoServicioId);
    }
}
