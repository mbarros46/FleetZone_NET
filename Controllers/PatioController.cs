using Microsoft.AspNetCore.Mvc;
using MottuCrudAPI.Application.DTOs;
using MottuCrudAPI.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MottuCrudAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatioController : ControllerBase
    {
        private readonly IPatioService _patioService;

        public PatioController(IPatioService patioService)
        {
            _patioService = patioService;
        }

        /// <summary>
        /// Obtém todos os pátios com filtros opcionais
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PatioDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] string? nome, [FromQuery] string? endereco)
        {
            try
            {
                var patios = await _patioService.GetAllAsync(nome, endereco);
                return Ok(patios);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtém um pátio específico pelo ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PatioDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var patio = await _patioService.GetByIdAsync(id);
            if (patio == null)
                return NotFound(new { message = "Pátio não encontrado" });

            return Ok(patio);
        }

        /// <summary>
        /// Cria um novo pátio
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(PatioDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] PatioDTO patioDTO)
        {
            try
            {
                var createdPatio = await _patioService.CreateAsync(patioDTO);
                return CreatedAtAction(nameof(GetById), new { id = createdPatio.Id }, createdPatio);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza um pátio existente
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PatioDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] PatioDTO patioDTO)
        {
            try
            {
                var updatedPatio = await _patioService.UpdateAsync(id, patioDTO);
                if (updatedPatio == null)
                    return NotFound(new { message = "Pátio não encontrado" });

                return Ok(updatedPatio);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Remove um pátio
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _patioService.DeleteAsync(id);
            if (!result)
                return NotFound(new { message = "Pátio não encontrado" });

            return NoContent();
        }
    }
} 