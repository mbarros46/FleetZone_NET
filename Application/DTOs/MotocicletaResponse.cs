public class MotocicletaResponse
{
    public int Id { get; set; }
    public string Placa { get; set; } = default!;
    public string Modelo { get; set; } = default!;
    public string Status { get; set; } = default!;
    public int PatioId { get; set; }
    public IEnumerable<LinkDto> Links { get; set; } = Enumerable.Empty<LinkDto>();
}
