using System.ComponentModel.DataAnnotations;

namespace MottuCrudAPI.Domain.Entities
{
    public class Patio
    {
        public int Id { get; private set; }
        
        [Required]
        [StringLength(100)]
        public string Nome { get; private set; }
        
        [Required]
        public string Endereco { get; private set; }
        
        [Required]
        public int Capacidade { get; private set; }
        
        public ICollection<Moto> Motos { get; private set; }

        private Patio() { } // For EF Core

        public Patio(string nome, string endereco, int capacidade)
        {
            ValidarNome(nome);
            ValidarEndereco(endereco);
            ValidarCapacidade(capacidade);

            Nome = nome;
            Endereco = endereco;
            Capacidade = capacidade;
            Motos = new List<Moto>();
        }

        public void Atualizar(string nome, string endereco, int capacidade)
        {
            ValidarNome(nome);
            ValidarEndereco(endereco);
            ValidarCapacidade(capacidade);

            Nome = nome;
            Endereco = endereco;
            Capacidade = capacidade;
        }

        public bool TemCapacidadeDisponivel()
        {
            return Motos.Count < Capacidade;
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome não pode ser vazio", nameof(nome));
        }

        private void ValidarEndereco(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("O endereço não pode ser vazio", nameof(endereco));
        }

        private void ValidarCapacidade(int capacidade)
        {
            if (capacidade <= 0)
                throw new ArgumentException("A capacidade deve ser maior que zero", nameof(capacidade));
        }
    }
} 