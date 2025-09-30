using System.ComponentModel.DataAnnotations;

/// <summary>
/// Representa a carga útil necessária para criar ou atualizar uma motocicleta.
/// </summary>
public class MotocicletaRequest
{
    /// <summary>
    /// Placa da motocicleta no padrão Mercosul.
    /// </summary>
    [Required]
    [StringLength(8, MinimumLength = 7)]
    public string Placa { get; set; } = default!;

    /// <summary>
    /// Modelo da motocicleta.
    /// </summary>
    [Required]
    [StringLength(80)]
    public string Modelo { get; set; } = default!;

    /// <summary>
    /// Identificador do pátio ao qual a motocicleta está associada.
    /// </summary>
    [Range(1, int.MaxValue)]
    public int PatioId { get; set; }
}
