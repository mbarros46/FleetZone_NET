using Microsoft.EntityFrameworkCore;
using FleetZone_NET.Infrastructure;

namespace FleetZone_NET.Infrastructure.Repositories
{
    public class MotocicletaRepository : IMotocicletaRepository
    {
        private readonly AppDbContext _ctx;
        public MotocicletaRepository(AppDbContext ctx) => _ctx = ctx;

    public async Task<Motocicleta?> GetAsync(int id) =>
        await _ctx.Motocicletas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<(IEnumerable<Motocicleta> items, int total)> GetPagedAsync(int pageNumber, int pageSize)
    {
        var query = _ctx.Motocicletas.AsNoTracking().OrderBy(x => x.Id);
        var total = await query.CountAsync();
        var items = await query.Skip((pageNumber - 1)*pageSize).Take(pageSize).ToListAsync();
        return (items, total);
    }

    public async Task<Motocicleta> AddAsync(Motocicleta entity)
    {
        _ctx.Motocicletas.Add(entity);
        await _ctx.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Motocicleta entity)
    {
        _ctx.Motocicletas.Update(entity);
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(Motocicleta entity)
    {
        _ctx.Motocicletas.Remove(entity);
        await _ctx.SaveChangesAsync();
    }
    }
}
