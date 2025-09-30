using System.ComponentModel.DataAnnotations;

namespace MottuCrudAPI.DTO.Request
{
    /// <summary>
    /// Representa o payload para criar ou atualizar um pátio.
    /// </summary>
    public class PatioRequest
    {
        /// <summary>
        /// Nome de identificação do pátio.
        /// </summary>
        [Required]
        [StringLength(120)]
        public string Nome { get; set; } = default!;

        /// <summary>
        /// Endereço completo do pátio.
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Endereco { get; set; } = default!;

        /// <summary>
        /// Capacidade máxima de motos suportada pelo pátio.
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Capacidade { get; set; }
    }
}
