public class MovimentacaoResponse
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public string Tipo { get; set; } = default!;
    public string? Observacao { get; set; }
    public int MotocicletaId { get; set; }
    public int PatioId { get; set; }
    public IEnumerable<LinkDto> Links { get; set; } = Enumerable.Empty<LinkDto>();
}
