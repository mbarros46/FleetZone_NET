public interface IPatioRepository
{
    Task<Patio?> GetAsync(Guid id);
    Task<(IEnumerable<Patio> items, int total)> GetPagedAsync(int pageNumber, int pageSize);
    Task<Patio> AddAsync(Patio entity);
    Task UpdateAsync(Patio entity);
    Task DeleteAsync(Patio entity);
}
