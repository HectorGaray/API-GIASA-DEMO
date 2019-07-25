using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIGIASA.Data;
using APIGIASA.Models;

namespace APIGIASA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatInsumoesController : ControllerBase
    {
        private readonly GiasaContext _context;

        public CatInsumoesController(GiasaContext context)
        {
            _context = context;
        }

        // GET: api/CatInsumoes
        [HttpGet]
        public IEnumerable<CatInsumo> GetCatInsumo()
        {
            return _context.CatInsumo;
        }

        // GET: api/CatInsumoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCatInsumo([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var catInsumo = await _context.CatInsumo.FindAsync(id);

            if (catInsumo == null)
            {
                return NotFound();
            }

            return Ok(catInsumo);
        }

        // PUT: api/CatInsumoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatInsumo([FromRoute] short id, [FromBody] CatInsumo catInsumo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catInsumo.idCatinsumo)
            {
                return BadRequest();
            }

            _context.Entry(catInsumo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatInsumoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CatInsumoes
        [HttpPost]
        public async Task<IActionResult> PostCatInsumo([FromBody] CatInsumo catInsumo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CatInsumo.Add(catInsumo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatInsumo", new { id = catInsumo.idCatinsumo }, catInsumo);
        }

        // DELETE: api/CatInsumoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatInsumo([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var catInsumo = await _context.CatInsumo.FindAsync(id);
            if (catInsumo == null)
            {
                return NotFound();
            }

            _context.CatInsumo.Remove(catInsumo);
            await _context.SaveChangesAsync();

            return Ok(catInsumo);
        }

        private bool CatInsumoExists(short id)
        {
            return _context.CatInsumo.Any(e => e.idCatinsumo == id);
        }
    }
}