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
    public class mano_obraController : ControllerBase
    {
        private readonly GiasaContext _context;

        public mano_obraController(GiasaContext context)
        {
            _context = context;
        }

        // GET: api/mano_obra
        [HttpGet]
        public IEnumerable<mano_obra> Getmano_obra()
        {
            return _context.mano_obra;
        }

        // GET: api/mano_obra/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getmano_obra([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mano_obra = await _context.mano_obra.FindAsync(id);

            if (mano_obra == null)
            {
                return NotFound();
            }

            return Ok(mano_obra);
        }

        // PUT: api/mano_obra/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmano_obra([FromRoute] int id, [FromBody] mano_obra mano_obra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mano_obra.idmano)
            {
                return BadRequest();
            }

            _context.Entry(mano_obra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mano_obraExists(id))
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

        // POST: api/mano_obra
        [HttpPost]
        public async Task<IActionResult> Postmano_obra([FromBody] mano_obra mano_obra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.mano_obra.Add(mano_obra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmano_obra", new { id = mano_obra.idmano }, mano_obra);
        }

        // DELETE: api/mano_obra/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemano_obra([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mano_obra = await _context.mano_obra.FindAsync(id);
            if (mano_obra == null)
            {
                return NotFound();
            }

            _context.mano_obra.Remove(mano_obra);
            await _context.SaveChangesAsync();

            return Ok(mano_obra);
        }

        private bool mano_obraExists(int id)
        {
            return _context.mano_obra.Any(e => e.idmano == id);
        }
    }
}