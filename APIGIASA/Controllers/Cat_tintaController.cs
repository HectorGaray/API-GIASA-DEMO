using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIGIASA.Data;
using APIGIASA.Models;
using Newtonsoft.Json;


namespace APIGIASA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cat_tintaController : ControllerBase
    {
        private readonly GiasaContext _context;

        public Cat_tintaController(GiasaContext context)
        {
            _context = context;
        }

        // GET: api/Cat_tinta
        [HttpGet]
        public ContentResult GetCat_tinta()
        {
            var consulta = from c in _context.Cat_tinta
                           select new
                           {
                               c.idTinta,
                               c.nombretin,
                               c.precio,
                           };

            String Serializa = JsonConvert.SerializeObject(consulta);
            return Content(Serializa, "application/json");


            
        }

        // GET: api/Cat_tinta/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCat_tinta([FromRoute] Int32 id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cat_tinta = await _context.Cat_tinta.FindAsync(id);

            if (cat_tinta == null)
            {
                return NotFound("No existe la colonia con el id: " + id);
            }

            return Ok(cat_tinta);
        }

        // PUT: api/Cat_tinta/5
        [HttpPut("{id}")]
        public ContentResult UpdateCat_Tinta([FromBody] Cat_tinta tin)
        {
            if (tin != null)
            {
                _context.Cat_tinta.Update(tin);
                try
                {

                    var response = _context.SaveChanges();
                    return Content("{'Respuesta':'Operacion exitosa','registros actualizados ':'" + response + "'}", "application/json");
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
                {
                    return Content("{'Respuesta':Error!','Exception':'" + e.Message + "'}", "application/json");
                }
            }
            else
            {
                return Content("{'Respuesta':'HORROR!!'}", "application/json");
            }
        }

        // POST: api/Cat_tinta
        [HttpPost]
        public async Task<IActionResult> PostCat_tinta([FromBody] Cat_tinta cat_tinta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cat_tinta.Add(cat_tinta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCat_tinta", new { id = cat_tinta.idTinta }, cat_tinta);
        }

        // DELETE: api/Cat_tinta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCat_tinta([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cat_tinta = await _context.Cat_tinta.FindAsync(id);
            if (cat_tinta == null)
            {
                return NotFound();
            }

            _context.Cat_tinta.Remove(cat_tinta);
            await _context.SaveChangesAsync();

            return Ok(cat_tinta);
        }

        private bool Cat_tintaExists(short id)
        {
            return _context.Cat_tinta.Any(e => e.idTinta == id);
        }
    }
}