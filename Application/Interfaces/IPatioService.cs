using MottuCrudAPI.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MottuCrudAPI.Application.Interfaces
{
    public interface IPatioService
    {
        Task<IEnumerable<PatioDTO>> GetAllAsync(string? nome = null, string? endereco = null);
        Task<PatioDTO> GetByIdAsync(int id);
        Task<PatioDTO> CreateAsync(PatioDTO patioDTO);
        Task<PatioDTO> UpdateAsync(int id, PatioDTO patioDTO);
        Task<bool> DeleteAsync(int id);
    }
} 