using System.ComponentModel.DataAnnotations;

namespace MottuCrudAPI.Domain.Entities
{
    public class Moto
    {
        public int Id { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public int Ano { get; set; }
        public int? PatioId { get; set; }
        public Patio? Patio { get; set; }
    }
} 