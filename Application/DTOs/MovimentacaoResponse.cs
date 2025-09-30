/// <summary>
/// Representa os dados expostos pela API para uma movimentação de motocicleta.
/// </summary>
public class MovimentacaoResponse
{
    /// <summary>
    /// Identificador exclusivo da movimentação.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Data e hora em que a movimentação ocorreu.
    /// </summary>
    public DateTime DataHora { get; set; }

    /// <summary>
    /// Tipo categórico da movimentação.
    /// </summary>
    public string Tipo { get; set; } = default!;

    /// <summary>
    /// Observações adicionais fornecidas no registro.
    /// </summary>
    public string? Observacao { get; set; }

    /// <summary>
    /// Identificador da motocicleta associada à movimentação.
    /// </summary>
    public int MotocicletaId { get; set; }

    /// <summary>
    /// Identificador do pátio relacionado ao evento.
    /// </summary>
    public int PatioId { get; set; }

    /// <summary>
    /// Links HATEOAS que descrevem ações relacionadas.
    /// </summary>
    public IEnumerable<LinkDto> Links { get; set; } = Enumerable.Empty<LinkDto>();
}
