namespace c_.DTO.Request
{
    public class MotoRequest
    {
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Status { get; set; }
        public MotoRequest(string modelo, string placa, string status)
        {
            Modelo = modelo;
            Placa = placa;
            Status = status;
        }
    }
}
