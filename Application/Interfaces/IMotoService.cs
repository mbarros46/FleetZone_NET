using MottuCrudAPI.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MottuCrudAPI.Application.Interfaces
{
    public interface IMotoService
    {
        Task<IEnumerable<MotoDTO>> GetAllAsync(string? placa = null, string? modelo = null);
        Task<MotoDTO> GetByIdAsync(int id);
        Task<MotoDTO> CreateAsync(MotoDTO motoDTO);
        Task<MotoDTO> UpdateAsync(int id, MotoDTO motoDTO);
        Task<bool> DeleteAsync(int id);
    }
} 