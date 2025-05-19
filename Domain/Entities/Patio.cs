using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MottuCrudAPI.Domain.Entities
{
    public class Patio
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;
        
        [Required]
        public string Endereco { get; set; } = string.Empty;
        
        [Required]
        public int Capacidade { get; set; }
        
        public ICollection<Moto> Motos { get; set; } = new List<Moto>();

        public Patio() { }

        public Patio(string nome, string endereco, int capacidade)
        {
            ValidarNome(nome);
            ValidarEndereco(endereco);
            ValidarCapacidade(capacidade);

            Nome = nome;
            Endereco = endereco;
            Capacidade = capacidade;
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