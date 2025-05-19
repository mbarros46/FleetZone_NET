namespace c_.Infrastructure.Persistence
{
    public class Moto
    {
        public Moto(string modelo, string placa, string status)
        {
            Modelo = modelo;
            Placa = placa;
            Status = status;
        }

        public Guid Id { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Status { get; set; }

        

        internal static Moto Create(string modelo, string placa, string status)
        {
            return new Moto(modelo, placa, status);
        }

        internal void AttDados(string placa, string modelo, string status)
        {
            Placa = placa;
            Modelo = modelo;
            Status = status;

            if (string.IsNullOrEmpty(placa))
                throw new ArgumentException("Placa não pode ser nula ou vazia");
        }
    }
}
