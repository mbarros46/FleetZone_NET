public class Movimentacao
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; } = DateTime.UtcNow;
    public string Tipo { get; set; } = default!; // Entrada, Saida, Avaria
    public string? Observacao { get; set; }
    public int MotocicletaId { get; set; }
    public Motocicleta Motocicleta { get; set; } = default!;
    public int PatioId { get; set; }
    public Patio Patio { get; set; } = default!;
}
