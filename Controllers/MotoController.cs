using Microsoft.AspNetCore.Mvc;
using MottuCrudAPI.Application.DTOs;
using MottuCrudAPI.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MottuCrudAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController : ControllerBase
    {
        private readonly IMotoService _motoService;

        public MotoController(IMotoService motoService)
        {
            _motoService = motoService;
        }

        /// <summary>
        /// Obtém todas as motos com filtros opcionais
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MotoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] string? placa, [FromQuery] string? modelo)
        {
            try
            {
                var motos = await _motoService.GetAllAsync(placa, modelo);
                return Ok(motos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtém uma moto específica pelo ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MotoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var moto = await _motoService.GetByIdAsync(id);
            if (moto == null)
                return NotFound(new { message = "Moto não encontrada" });

            return Ok(moto);
        }

        /// <summary>
        /// Cria uma nova moto
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(MotoDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] MotoDTO motoDTO)
        {
            try
            {
                var createdMoto = await _motoService.CreateAsync(motoDTO);
                return CreatedAtAction(nameof(GetById), new { id = createdMoto.Id }, createdMoto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza uma moto existente
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(MotoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] MotoDTO motoDTO)
        {
            try
            {
                var updatedMoto = await _motoService.UpdateAsync(id, motoDTO);
                if (updatedMoto == null)
                    return NotFound(new { message = "Moto não encontrada" });

                return Ok(updatedMoto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Remove uma moto
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _motoService.DeleteAsync(id);
            if (!result)
                return NotFound(new { message = "Moto não encontrada" });

            return NoContent();
        }
    }
} 