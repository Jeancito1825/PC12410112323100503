using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PC12410112323100503.Core.Interfaces;
using PC12410112323100503.Entidades;

namespace PC12410112323100503.CORE.Infraestructure.Repositories
{
    public class OrdenServicioRepository : IOrdenServicioRepository
    {
        private readonly TallerContext _context;

        public OrdenServicioRepository(TallerContext context)
        {
            _context = context;
        }

        public async Task<OrdenServicio> CreateAsync(OrdenServicio ordenServicio)
        {
            _context.OrdenServicios.Add(ordenServicio);
            await _context.SaveChangesAsync();
            return ordenServicio;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.OrdenServicios.FindAsync(id);
            if (entity == null) return;
            _context.OrdenServicios.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrdenServicio>> GetAllAsync()
        {
            return await _context.OrdenServicios.AsNoTracking().ToListAsync();
        }

        public async Task<OrdenServicio?> GetByIdAsync(int id)
        {
            return await _context.OrdenServicios.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task UpdateAsync(OrdenServicio ordenServicio)
        {
            _context.OrdenServicios.Update(ordenServicio);
            await _context.SaveChangesAsync();
        }
    }
}
