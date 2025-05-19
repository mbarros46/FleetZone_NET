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
    public class PatioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PatioController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatioDTO>>> GetPatios()
        {
            var patios = await _context.Patios
                .Include(p => p.Motos)
                .ToListAsync();
            return Ok(_mapper.Map<IEnumerable<PatioDTO>>(patios));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatioDTO>> GetPatio(int id)
        {
            var patio = await _context.Patios
                .Include(p => p.Motos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patio == null)
                return NotFound();

            return Ok(_mapper.Map<PatioDTO>(patio));
        }

        [HttpPost]
        public async Task<ActionResult<PatioDTO>> CreatePatio(CreatePatioDTO createPatioDto)
        {
            var patio = _mapper.Map<Patio>(createPatioDto);
            _context.Patios.Add(patio);
            await _context.SaveChangesAsync();

            var patioDto = _mapper.Map<PatioDTO>(patio);
            return CreatedAtAction(nameof(GetPatio), new { id = patio.Id }, patioDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatio(int id, UpdatePatioDTO updatePatioDto)
        {
            var patio = await _context.Patios.FindAsync(id);
            if (patio == null)
                return NotFound();

            _mapper.Map(updatePatioDto, patio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatio(int id)
        {
            var patio = await _context.Patios.FindAsync(id);
            if (patio == null)
                return NotFound();

            _context.Patios.Remove(patio);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
} 