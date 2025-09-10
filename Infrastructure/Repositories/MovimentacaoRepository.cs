using Microsoft.EntityFrameworkCore;

public class MovimentacaoRepository : IMovimentacaoRepository
{
    private readonly AppDbContext _ctx;
    public MovimentacaoRepository(AppDbContext ctx) => _ctx = ctx;

    public async Task<Movimentacao?> GetAsync(int id) =>
        await _ctx.Movimentacoes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<(IEnumerable<Movimentacao> items, int total)> GetPagedAsync(int pageNumber, int pageSize)
    {
        var query = _ctx.Movimentacoes.AsNoTracking().OrderBy(x => x.Id);
        var total = await query.CountAsync();
        var items = await query.Skip((pageNumber - 1)*pageSize).Take(pageSize).ToListAsync();
        return (items, total);
    }

    public async Task<Movimentacao> AddAsync(Movimentacao entity)
    {
        _ctx.Movimentacoes.Add(entity);
        await _ctx.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Movimentacao entity)
    {
        _ctx.Movimentacoes.Update(entity);
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(Movimentacao entity)
    {
        _ctx.Movimentacoes.Remove(entity);
        await _ctx.SaveChangesAsync();
    }
}
