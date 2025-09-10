public interface IMotocicletaRepository
{
    Task<Motocicleta?> GetAsync(int id);
    Task<(IEnumerable<Motocicleta> items, int total)> GetPagedAsync(int pageNumber, int pageSize);
    Task<Motocicleta> AddAsync(Motocicleta entity);
    Task UpdateAsync(Motocicleta entity);
    Task DeleteAsync(Motocicleta entity);
}
