using System.ComponentModel.DataAnnotations;

namespace MottuCrudAPI.Domain.Entities
{
    public class Moto
    {
        public int Id { get; private set; }
        
        [Required]
        [StringLength(7)]
        public string Placa { get; private set; }
        
        [Required]
        public int Ano { get; private set; }
        
        [Required]
        public string Modelo { get; private set; }
        
        public int? PatioId { get; private set; }
        public Patio? Patio { get; private set; }

        private Moto() { } // For EF Core

        public Moto(string placa, int ano, string modelo)
        {
            ValidarPlaca(placa);
            ValidarAno(ano);
            ValidarModelo(modelo);

            Placa = placa;
            Ano = ano;
            Modelo = modelo;
        }

        public void Atualizar(string placa, int ano, string modelo)
        {
            ValidarPlaca(placa);
            ValidarAno(ano);
            ValidarModelo(modelo);

            Placa = placa;
            Ano = ano;
            Modelo = modelo;
        }

        public void AtribuirPatio(int patioId)
        {
            PatioId = patioId;
        }

        private void ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                throw new ArgumentException("A placa não pode ser vazia", nameof(placa));
            
            if (placa.Length != 7)
                throw new ArgumentException("A placa deve ter 7 caracteres", nameof(placa));
        }

        private void ValidarAno(int ano)
        {
            if (ano < 1900 || ano > DateTime.Now.Year)
                throw new ArgumentException("Ano inválido", nameof(ano));
        }

        private void ValidarModelo(string modelo)
        {
            if (string.IsNullOrWhiteSpace(modelo))
                throw new ArgumentException("O modelo não pode ser vazia", nameof(modelo));
        }
    }
} 