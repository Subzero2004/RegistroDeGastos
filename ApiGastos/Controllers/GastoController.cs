using ApiGastos.DTOs;
using ApiGastos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public GastoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GastoDTO>>> Get()
        {
            var gastos = await _context.Gastos
                .ToListAsync();

            var gastoDto = gastos.Select(g => new GastoDTO
            {
                id = g.ID,
                fecha = g.Fecha,
                descripcion = g.Descripcion,
                monto = g.Monto,
                nombrecomercio = g.NombreComercio
            }).ToList();

            return Ok(gastoDto);
        }

        [HttpPost]

        public async Task<ActionResult<Gasto>> Post(Gasto gasto)
        {
            if (gasto.Fecha > DateTime.Today)
            {
                return BadRequest("La fecha no puede ser futura.");
            }

            _context.Gastos.Add(gasto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = gasto }, gasto);
        }
    }
}
