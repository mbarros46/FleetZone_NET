namespace MottuCrudAPI.DTO.Response
{
    /// <summary>
    /// Representa os dados públicos de um pátio expostos pela API.
    /// </summary>
    public class PatioResponse
    {
        /// <summary>
        /// Identificador único do pátio.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome do pátio.
        /// </summary>
        public string Nome { get; set; } = default!;

        /// <summary>
        /// Endereço completo do pátio.
        /// </summary>
        public string Endereco { get; set; } = default!;

        /// <summary>
        /// Capacidade máxima suportada.
        /// </summary>
        public int Capacidade { get; set; }

        /// <summary>
        /// Quantidade atual de motos no pátio.
        /// </summary>
        public int OcupacaoAtual { get; set; }

        /// <summary>
        /// Links HATEOAS que descrevem ações relacionadas ao recurso.
        /// </summary>
        public IEnumerable<LinkDto> Links { get; set; } = Enumerable.Empty<LinkDto>();
    }
}