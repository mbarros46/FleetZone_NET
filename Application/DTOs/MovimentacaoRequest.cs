public class MovimentacaoRequest
{
    public string Tipo { get; set; } = default!;
    public string? Observacao { get; set; }
    public int MotocicletaId { get; set; }
    public int PatioId { get; set; }
}
