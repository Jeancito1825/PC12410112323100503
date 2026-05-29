using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PC12410112323100503.Core.Dtos;
using PC12410112323100503.Core.Interfaces;
using PC12410112323100503.Entidades;

namespace PC12410112323100503.CORE.Infraestructure.Services
{
    public class OrdenServicioService : IOrdenServicioService
    {
        private readonly IOrdenServicioRepository _repository;

        public OrdenServicioService(IOrdenServicioRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrdenServicioDto> CreateAsync(OrdenServicioDto dto)
        {
            var entity = new OrdenServicio
            {
                FechaIngreso = dto.FechaIngreso,
                DescripcionProblema = dto.DescripcionProblema,
                CostoEstimado = dto.CostoEstimado,
                Estado = dto.Estado,
                VehiculoId = dto.VehiculoId,
                TipoServicioId = dto.TipoServicioId
            };

            var created = await _repository.CreateAsync(entity);
            dto.Id = created.Id;
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrdenServicioDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(o => new OrdenServicioDto
            {
                Id = o.Id,
                FechaIngreso = o.FechaIngreso,
                DescripcionProblema = o.DescripcionProblema,
                CostoEstimado = o.CostoEstimado,
                Estado = o.Estado,
                VehiculoId = o.VehiculoId,
                TipoServicioId = o.TipoServicioId
            });
        }

        public async Task<OrdenServicioDto?> GetByIdAsync(int id)
        {
            var o = await _repository.GetByIdAsync(id);
            if (o == null) return null;
            return new OrdenServicioDto
            {
                Id = o.Id,
                FechaIngreso = o.FechaIngreso,
                DescripcionProblema = o.DescripcionProblema,
                CostoEstimado = o.CostoEstimado,
                Estado = o.Estado,
                VehiculoId = o.VehiculoId,
                TipoServicioId = o.TipoServicioId
            };
        }

        public async Task UpdateAsync(int id, OrdenServicioDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return;

            existing.FechaIngreso = dto.FechaIngreso;
            existing.DescripcionProblema = dto.DescripcionProblema;
            existing.CostoEstimado = dto.CostoEstimado;
            existing.Estado = dto.Estado;
            existing.VehiculoId = dto.VehiculoId;
            existing.TipoServicioId = dto.TipoServicioId;

            await _repository.UpdateAsync(existing);
        }
    }
}
