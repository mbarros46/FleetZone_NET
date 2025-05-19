namespace MottuCrudAPI.Application.DTOs
{
    public class PatioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Capacidade { get; set; }
        public int MotosCount { get; set; }
    }

    public class CreatePatioDTO
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Capacidade { get; set; }
    }

    public class UpdatePatioDTO
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Capacidade { get; set; }
    }
} 