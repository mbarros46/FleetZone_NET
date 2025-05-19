using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MottuCrudAPI.Application.DTOs;
using MottuCrudAPI.Domain.Entities;
using MottuCrudAPI.Infrastructure.Data;

namespace MottuCrudAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MotoController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotoDTO>>> GetMotos()
        {
            var motos = await _context.Motos
                .Include(m => m.Patio)
                .ToListAsync();
            return Ok(_mapper.Map<IEnumerable<MotoDTO>>(motos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MotoDTO>> GetMoto(int id)
        {
            var moto = await _context.Motos
                .Include(m => m.Patio)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (moto == null)
                return NotFound();

            return Ok(_mapper.Map<MotoDTO>(moto));
        }

        [HttpPost]
        public async Task<ActionResult<MotoDTO>> CreateMoto(CreateMotoDTO createMotoDto)
        {
            var moto = _mapper.Map<Moto>(createMotoDto);
            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();

            var motoDto = _mapper.Map<MotoDTO>(moto);
            return CreatedAtAction(nameof(GetMoto), new { id = moto.Id }, motoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMoto(int id, UpdateMotoDTO updateMotoDto)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
                return NotFound();

            _mapper.Map(updateMotoDto, moto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoto(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
                return NotFound();

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
} 