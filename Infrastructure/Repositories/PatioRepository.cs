using Microsoft.EntityFrameworkCore;
using FleetZone_NET.Infrastructure;

namespace FleetZone_NET.Infrastructure.Repositories
{
    public class PatioRepository : IPatioRepository
    {
        private readonly AppDbContext _ctx;
        public PatioRepository(AppDbContext ctx) => _ctx = ctx;

    public async Task<Patio?> GetAsync(Guid id) =>
        await _ctx.Patios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<(IEnumerable<Patio> items, int total)> GetPagedAsync(int pageNumber, int pageSize)
    {
        var query = _ctx.Patios.AsNoTracking().OrderBy(x => x.Id);
        var total = await query.CountAsync();
        var items = await query.Skip((pageNumber - 1)*pageSize).Take(pageSize).ToListAsync();
        return (items, total);
    }

    public async Task<Patio> AddAsync(Patio entity)
    {
        _ctx.Patios.Add(entity);
        await _ctx.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Patio entity)
    {
        _ctx.Patios.Update(entity);
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(Patio entity)
    {
        _ctx.Patios.Remove(entity);
        await _ctx.SaveChangesAsync();
    }
    }
}
