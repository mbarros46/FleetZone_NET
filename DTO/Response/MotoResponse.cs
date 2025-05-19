namespace c_.DTO.Response
{
    public class MotoResponse
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Status { get; set; }
        public MotoResponse(int id, string modelo, string placa, string status)
        {
            Id = id;
            Modelo = modelo;
            Placa = placa;
            Status = status;
        }
    }
}
