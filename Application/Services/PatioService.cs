using MottuCrudAPI.Application.DTOs;
using MottuCrudAPI.Application.Interfaces;
using MottuCrudAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MottuCrudAPI.Application.Services
{
    public class PatioService : IPatioService
    {
        private readonly ApplicationDbContext _context;

        public PatioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatioDTO>> GetAllAsync(string? nome = null, string? endereco = null)
        {
            var query = _context.Patios.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
                query = query.Where(p => p.Nome.Contains(nome));

            if (!string.IsNullOrEmpty(endereco))
                query = query.Where(p => p.Endereco.Contains(endereco));

            var patios = await query.ToListAsync();
            return patios.Select(p => new PatioDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Endereco = p.Endereco,
                Capacidade = p.Capacidade,
                MotosCount = p.Motos?.Count ?? 0
            });
        }

        public async Task<PatioDTO> GetByIdAsync(int id)
        {
            var patio = await _context.Patios
                .Include(p => p.Motos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patio == null)
                return null;

            return new PatioDTO
            {
                Id = patio.Id,
                Nome = patio.Nome,
                Endereco = patio.Endereco,
                Capacidade = patio.Capacidade,
                MotosCount = patio.Motos?.Count ?? 0
            };
        }

        public async Task<PatioDTO> CreateAsync(PatioDTO patioDTO)
        {
            var patio = new Domain.Entities.Patio
            {
                Nome = patioDTO.Nome,
                Endereco = patioDTO.Endereco,
                Capacidade = patioDTO.Capacidade
            };

            _context.Patios.Add(patio);
            await _context.SaveChangesAsync();

            patioDTO.Id = patio.Id;
            return patioDTO;
        }

        public async Task<PatioDTO> UpdateAsync(int id, PatioDTO patioDTO)
        {
            var patio = await _context.Patios.FindAsync(id);
            if (patio == null)
                return null;

            patio.Nome = patioDTO.Nome;
            patio.Endereco = patioDTO.Endereco;
            patio.Capacidade = patioDTO.Capacidade;

            await _context.SaveChangesAsync();

            patioDTO.Id = patio.Id;
            return patioDTO;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var patio = await _context.Patios.FindAsync(id);
            if (patio == null)
                return false;

            _context.Patios.Remove(patio);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 