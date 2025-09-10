public class Patio
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = default!;
    public string Endereco { get; set; } = default!;
    public int Capacidade { get; set; }
    public int OcupacaoAtual { get; set; }
    public ICollection<Motocicleta> Motocicletas { get; set; } = new List<Motocicleta>();

    public static Patio Create(string nome, string endereco, int capacidade)
    {
        return new Patio
        {
            Id = Guid.NewGuid(),
            Nome = nome,
            Endereco = endereco,
            Capacidade = capacidade,
            OcupacaoAtual = 0
        };
    }

    public void AtualizarPatio(string nome, string endereco, int capacidade)
    {
        Nome = nome;
        Endereco = endereco;
        Capacidade = capacidade;
    }
}
