using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoP2.Contexto;
using ProjetoP2.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoP2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamisasController : ControllerBase
    {
        private readonly RoletaContextMySQL _context;

        public CamisasController(RoletaContextMySQL context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Camisas>> GetCamisas()
        {
            return _context.Camisas.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Camisas> GetCamisas(int id)
        {
            var camisas = _context.Camisas.Find(id);

            if (camisas == null)
            {
                return NotFound();
            }

            return camisas;
        }

        [HttpPost]
        public ActionResult<Camisas> PostCamisas(Camisas camisas)
        {
            _context.Camisas.Add(camisas);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCamisas), new { id = camisas.Id }, camisas);
        }

        [HttpPut("{id}")]
        public IActionResult PutCamisas(int id, Camisas camisas)
        {
            if (id != camisas.Id)
            {
                return BadRequest();
            }

            _context.Entry(camisas).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCamisas(int id)
        {
            var camisas = _context.Camisas.Find(id);

            if (camisas == null)
            {
                return NotFound();
            }

            _context.Camisas.Remove(camisas);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
