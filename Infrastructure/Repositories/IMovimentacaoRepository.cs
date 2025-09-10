public interface IMovimentacaoRepository
{
    Task<Movimentacao?> GetAsync(int id);
    Task<(IEnumerable<Movimentacao> items, int total)> GetPagedAsync(int pageNumber, int pageSize);
    Task<Movimentacao> AddAsync(Movimentacao entity);
    Task UpdateAsync(Movimentacao entity);
    Task DeleteAsync(Movimentacao entity);
}
