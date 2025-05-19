using System.ComponentModel.DataAnnotations;

namespace MottuCrudAPI.Application.DTOs
{
    public class PatioDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O endereço é obrigatório")]
        public string Endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = "A capacidade é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A capacidade deve ser maior que zero")]
        public int Capacidade { get; set; }

        public int MotosCount { get; set; }
    }

    public class CreatePatioDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public int Capacidade { get; set; }
    }

    public class UpdatePatioDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public int Capacidade { get; set; }
    }
} 