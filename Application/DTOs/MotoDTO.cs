namespace MottuCrudAPI.Application.DTOs
{
    public class MotoDTO
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public string Modelo { get; set; }
        public int? PatioId { get; set; }
        public string? PatioNome { get; set; }
    }

    public class CreateMotoDTO
    {
        public string Placa { get; set; }
        public int Ano { get; set; }
        public string Modelo { get; set; }
        public int? PatioId { get; set; }
    }

    public class UpdateMotoDTO
    {
        public string Placa { get; set; }
        public int Ano { get; set; }
        public string Modelo { get; set; }
        public int? PatioId { get; set; }
    }
} 