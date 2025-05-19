using MottuCrudAPI.Application.DTOs;
using MottuCrudAPI.Application.Interfaces;
using MottuCrudAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MottuCrudAPI.Application.Services
{
    public class MotoService : IMotoService
    {
        private readonly ApplicationDbContext _context;

        public MotoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MotoDTO>> GetAllAsync(string? placa = null, string? modelo = null)
        {
            var query = _context.Motos.AsQueryable();

            if (!string.IsNullOrEmpty(placa))
                query = query.Where(m => m.Placa.Contains(placa));

            if (!string.IsNullOrEmpty(modelo))
                query = query.Where(m => m.Modelo.Contains(modelo));

            var motos = await query.ToListAsync();
            return motos.Select(m => new MotoDTO
            {
                Id = m.Id,
                Placa = m.Placa,
                Modelo = m.Modelo,
                Marca = m.Marca,
                Ano = m.Ano,
                PatioId = m.PatioId
            });
        }

        public async Task<MotoDTO> GetByIdAsync(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
                return null;

            return new MotoDTO
            {
                Id = moto.Id,
                Placa = moto.Placa,
                Modelo = moto.Modelo,
                Marca = moto.Marca,
                Ano = moto.Ano,
                PatioId = moto.PatioId
            };
        }

        public async Task<MotoDTO> CreateAsync(MotoDTO motoDTO)
        {
            var moto = new Domain.Entities.Moto
            {
                Placa = motoDTO.Placa,
                Modelo = motoDTO.Modelo,
                Marca = motoDTO.Marca,
                Ano = motoDTO.Ano,
                PatioId = motoDTO.PatioId
            };

            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();

            motoDTO.Id = moto.Id;
            return motoDTO;
        }

        public async Task<MotoDTO> UpdateAsync(int id, MotoDTO motoDTO)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
                return null;

            moto.Placa = motoDTO.Placa;
            moto.Modelo = motoDTO.Modelo;
            moto.Marca = motoDTO.Marca;
            moto.Ano = motoDTO.Ano;
            moto.PatioId = motoDTO.PatioId;

            await _context.SaveChangesAsync();

            motoDTO.Id = moto.Id;
            return motoDTO;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
                return false;

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 