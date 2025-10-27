using System.ComponentModel.DataAnnotations;

namespace FleetZone_NET.Application.DTOs
{
    /// <summary>
    /// Representa a carga necessária para registrar uma movimentação de motocicleta.
    /// </summary>
    public class MovimentacaoRequest
    {
    /// <summary>
    /// Tipo da movimentação (por exemplo, Entrada, Saída, Transferência).
    /// </summary>
    [Required]
    [StringLength(40)]
    public string Tipo { get; set; } = default!;

    /// <summary>
    /// Observações adicionais relacionadas à movimentação.
    /// </summary>
    [StringLength(255)]
    public string? Observacao { get; set; }

    /// <summary>
    /// Identificador da motocicleta movimentada.
    /// </summary>
    [Range(1, int.MaxValue)]
    public int MotocicletaId { get; set; }

    /// <summary>
    /// Identificador do pátio de origem/destino.
    /// </summary>
    public Guid PatioId { get; set; }
    }
}
