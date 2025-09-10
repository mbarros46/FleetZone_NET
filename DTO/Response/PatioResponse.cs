namespace MottuCrudAPI.DTO.Response
{
    public class PatioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = default!;
        public string Endereco { get; set; } = default!;
        public int Capacidade { get; set; }
        public int OcupacaoAtual { get; set; }
    }
}