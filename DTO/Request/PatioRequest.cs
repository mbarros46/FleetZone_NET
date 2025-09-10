namespace MottuCrudAPI.DTO.Request
{
    public class PatioRequest
    {
        public string Nome { get; set; } = default!;
        public string Endereco { get; set; } = default!;
        public int Capacidade { get; set; }
    }
}
