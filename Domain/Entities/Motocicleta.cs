public class Motocicleta
{
    public int Id { get; set; }
    public string Placa { get; set; } = default!;
    public string Modelo { get; set; } = default!;
    public string Status { get; set; } = "Disponivel"; // Disponivel, EmUso, Manutencao
    public int PatioId { get; set; }
    public Patio Patio { get; set; } = default!;
    public ICollection<Movimentacao> Movimentacoes { get; set; } = new List<Movimentacao>();
}
