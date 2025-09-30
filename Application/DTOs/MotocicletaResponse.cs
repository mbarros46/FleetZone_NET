/// <summary>
/// Representa os dados expostos pela API para uma motocicleta, incluindo links HATEOAS.
/// </summary>
public class MotocicletaResponse
{
    /// <summary>
    /// Identificador exclusivo da motocicleta.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Placa cadastrada da motocicleta.
    /// </summary>
    public string Placa { get; set; } = default!;

    /// <summary>
    /// Modelo descritivo da motocicleta.
    /// </summary>
    public string Modelo { get; set; } = default!;

    /// <summary>
    /// Status operacional atual da motocicleta.
    /// </summary>
    public string Status { get; set; } = default!;

    /// <summary>
    /// Identificador do pátio associado.
    /// </summary>
    public int PatioId { get; set; }

    /// <summary>
    /// Coleção de links HATEOAS relacionados à motocicleta.
    /// </summary>
    public IEnumerable<LinkDto> Links { get; set; } = Enumerable.Empty<LinkDto>();
}
