using System.ComponentModel.DataAnnotations;

namespace MottuCrudAPI.Application.DTOs
{
    public class MotoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A placa é obrigatória")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "A placa deve ter 7 caracteres")]
        public string Placa { get; set; } = string.Empty;

        [Required(ErrorMessage = "O modelo é obrigatório")]
        public string Modelo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A marca é obrigatória")]
        public string Marca { get; set; } = string.Empty;

        [Required(ErrorMessage = "O ano é obrigatório")]
        [Range(1900, 2100, ErrorMessage = "O ano deve estar entre 1900 e 2100")]
        public int Ano { get; set; }

        public int? PatioId { get; set; }
    }

    public class CreateMotoDTO
    {
        public string Placa { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public int? PatioId { get; set; }
    }

    public class UpdateMotoDTO
    {
        public string Placa { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public int? PatioId { get; set; }
    }
} 