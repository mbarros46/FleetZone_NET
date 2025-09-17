using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using MottuCrudAPI.Persistense;
using MottuCrudAPI.Infrastructure;
using MottuCrudAPI.DTO.Response;
using MottuCrudAPI.DTO.Request;
using Swashbuckle.AspNetCore.Filters;
using MottuCrudAPI.WebApi.SwaggerExamples;

namespace MottuCrudAPI.Controllers
{
	[Route("api/v1/[controller]")]
	[Tags("Pátios")]
	[ApiController]
	public class PatioController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public PatioController(ApplicationDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Obtém todos os pátios com paginação, filtros opcionais por nome e endereço e HATEOAS
		/// </summary>
		/// <param name="pageNumber">Número da página (padrão: 1)</param>
		/// <param name="pageSize">Tamanho da página (padrão: 10, máximo: 50)</param>
		/// <param name="nome">Filtro opcional pelo nome do pátio</param>
		/// <param name="endereco">Filtro opcional pelo endereço</param>
		/// <returns>Lista paginada de pátios com links HATEOAS</returns>
		[HttpGet(Name = "GetPatios")]
		[ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
		public async Task<IActionResult> Get(
			[FromQuery] int pageNumber = 1,
			[FromQuery] int pageSize = 10,
			[FromQuery] string? nome = null,
			[FromQuery] string? endereco = null)
		{
			const int MaxPageSize = 50;
			pageNumber = pageNumber < 1 ? 1 : pageNumber;
			pageSize = pageSize > MaxPageSize ? MaxPageSize : pageSize;

			var query = _context.Patios.AsQueryable();
			if (!string.IsNullOrWhiteSpace(nome))
				query = query.Where(p => p.Nome.Contains(nome));
			if (!string.IsNullOrWhiteSpace(endereco))
				query = query.Where(p => p.Endereco.Contains(endereco));

			var total = await query.CountAsync();
			var items = await query
				.OrderBy(p => p.Id)
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			var responses = items.Select(p => new PatioResponse
			{
				Id = p.Id,
				Nome = p.Nome,
				Endereco = p.Endereco,
				Capacidade = p.Capacidade,
				OcupacaoAtual = p.OcupacaoAtual,
				Links = HateoasBuilder.ForPatio(p.Id, Url)
			});

			var paged = new PagedList<PatioResponse>(responses, total, pageNumber, pageSize);

			var lastPage = (int)Math.Ceiling(total / (double)pageSize);
			var collectionLinks = new[]
			{
				new LinkDto("self",  Url.Link("GetPatios", new { pageNumber, pageSize, nome, endereco })!, "GET"),
				new LinkDto("first", Url.Link("GetPatios", new { pageNumber = 1, pageSize, nome, endereco })!, "GET"),
				new LinkDto("last",  Url.Link("GetPatios", new { pageNumber = lastPage, pageSize, nome, endereco })!, "GET"),
			};

			return Ok(new
			{
				paged.PageNumber,
				paged.PageSize,
				paged.TotalCount,
				paged.TotalPages,
				links = collectionLinks,
				items = paged.Items
			});
		}

		/// <summary>
		/// Obtém um pátio pelo ID com links HATEOAS
		/// </summary>
		/// <param name="id">ID do pátio</param>
		/// <returns>Pátio encontrado com links HATEOAS ou NotFound</returns>
		[HttpGet("{id}", Name = "GetPatioById")]
		[ProducesResponseType(typeof(PatioResponse), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetById(Guid id)
		{
			var patio = await _context.Patios.FindAsync(id);
			if (patio == null)
				return NotFound();

			var dto = new PatioResponse
			{
				Id = patio.Id,
				Nome = patio.Nome,
				Endereco = patio.Endereco,
				Capacidade = patio.Capacidade,
				OcupacaoAtual = patio.OcupacaoAtual,
				Links = HateoasBuilder.ForPatio(patio.Id, Url)
			};

			return Ok(dto);
		}

		/// <summary>
		/// Cria um novo pátio
		/// </summary>
		/// <param name="patioRequest">Dados do pátio</param>
		/// <returns>Pátio criado</returns>
		[HttpPost(Name = "CreatePatio")]
		[SwaggerRequestExample(typeof(PatioRequest), typeof(PatioRequestExample))]
		[ProducesResponseType(typeof(PatioResponse), StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Post([FromBody] PatioRequest patioRequest)
		{
			if (patioRequest == null)
				return BadRequest();

			var patio = Patio.Create(patioRequest.Nome, patioRequest.Endereco, patioRequest.Capacidade);

			_context.Patios.Add(patio);
			await _context.SaveChangesAsync();

			var patioResponse = new PatioResponse
			{
				Id = patio.Id,
				Nome = patio.Nome,
				Endereco = patio.Endereco,
				Capacidade = patio.Capacidade,
				Links = HateoasBuilder.ForPatio(patio.Id, Url)
			};

			return CreatedAtAction(nameof(GetById), new { id = patio.Id }, patioResponse);
		}

		/// <summary>
		/// Atualiza um pátio existente
		/// </summary>
		/// <param name="id">ID do pátio a atualizar</param>
		/// <param name="patioRequest">Dados atualizados do pátio</param>
		/// <returns>Pátio atualizado ou NotFound</returns>
		[HttpPut("{id}", Name = "UpdatePatio")]
		[SwaggerRequestExample(typeof(PatioRequest), typeof(PatioRequestExample))]
		[ProducesResponseType(typeof(PatioResponse), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Put(Guid id, [FromBody] PatioRequest patioRequest)
		{
			var patioExistente = await _context.Patios.FindAsync(id);
			if (patioExistente == null)
				return NotFound();

			try
			{
				patioExistente.AtualizarPatio(patioRequest.Nome, patioRequest.Endereco, patioRequest.Capacidade);
				await _context.SaveChangesAsync();
                
				var response = new PatioResponse
				{
					Id = patioExistente.Id,
					Nome = patioExistente.Nome,
					Endereco = patioExistente.Endereco,
					Capacidade = patioExistente.Capacidade,
					OcupacaoAtual = patioExistente.OcupacaoAtual,
					Links = HateoasBuilder.ForPatio(patioExistente.Id, Url)
				};
                
				return Ok(response);
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.InnerException?.Message ?? ex.Message });
			}
		}

		/// <summary>
		/// Remove um pátio pelo ID
		/// </summary>
		/// <param name="id">ID do pátio</param>
		/// <returns>NoContent ou mensagem de erro</returns>
		[HttpDelete("{id}", Name = "DeletePatio")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Delete(Guid id)
		{
			var patio = await _context.Patios.FindAsync(id);
			if (patio == null)
				return NotFound();

			// Buscar motos associadas 
			var motosAssociadas = await _context.Motos
				.Where(m => m.PatioId != null)
				.ToListAsync();

			bool existeMotoAssociada = motosAssociadas.Any(m => m.PatioId == id);

			if (existeMotoAssociada)
			{
				return BadRequest(new
				{
					message = "Não é possível deletar o pátio: existem motos associadas a ele."
				});
			}

			// removendo o pátio
			_context.Patios.Remove(patio);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}