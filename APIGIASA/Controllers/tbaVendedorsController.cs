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
    public class tbaVendedorsController : ControllerBase
    {
        private readonly GiasaContext _context;

        public tbaVendedorsController(GiasaContext context)
        {
            _context = context;
        }

        // GET: api/tbaVendedors
        [HttpGet]
        public async Task<ActionResult> GettbaVendedor()
        {
            var consulta = from c in _context.tbaVendedor
                           select new
                           {
                               c.idVendedor,
                               c.nombre,
                               c.usuario,
                           };

            String Serializa = JsonConvert.SerializeObject(consulta);
            return Content(Serializa, "application/json");
        }
        

        public class vendedorinfo //clase para crear json 
        {
            public String usuario { get; set; }
            public String pass { get; set; }
        }

        [HttpPut]
        [Route("login")]
        public ContentResult login([FromBody] vendedorinfo info)
        {
            if(info != null)
            {
                bool res = _context.tbaVendedor.Any(x => x.usuario == info.usuario && x.pass == info.pass);



                if(res)
                {
                    vendedorinfo salida = new vendedorinfo();
                    salida.usuario = "Correcto";
                    salida.pass = "Correcto";

                    String content= JsonConvert.SerializeObject(salida);
                    return Content(content, "application/json");

                }
                vendedorinfo salida2 = new vendedorinfo();
                salida2.usuario = "NO";
                salida2.pass = "No";

                String content2 = JsonConvert.SerializeObject(salida2);
                return Content(content2, "application/json");


            }

            return Content("HEOEl");
        }


        // GET: api/tbaVendedors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GettbaVendedor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tbaVendedor = await _context.tbaVendedor.FindAsync(id);

            if (tbaVendedor == null)
            {
                return NotFound();
            }

            return Ok(tbaVendedor);
        }

        // PUT: api/tbaVendedors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttbaVendedor([FromRoute] int id, [FromBody] tbaVendedor tbaVendedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbaVendedor.idVendedor)
            {
                return BadRequest();
            }

            _context.Entry(tbaVendedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbaVendedorExists(id))
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

        // POST: api/tbaVendedors
        [HttpPost]
        public async Task<IActionResult> PosttbaVendedor([FromBody] tbaVendedor tbaVendedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.tbaVendedor.Add(tbaVendedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettbaVendedor", new { id = tbaVendedor.idVendedor }, tbaVendedor);
        }

        // DELETE: api/tbaVendedors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetbaVendedor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tbaVendedor = await _context.tbaVendedor.FindAsync(id);
            if (tbaVendedor == null)
            {
                return NotFound();
            }

            _context.tbaVendedor.Remove(tbaVendedor);
            await _context.SaveChangesAsync();

            return Ok(tbaVendedor);
        }

        private bool tbaVendedorExists(int id)
        {
            return _context.tbaVendedor.Any(e => e.idVendedor == id);
        }

        

    }
}