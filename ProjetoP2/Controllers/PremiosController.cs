using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoP2.Contexto;
using ProjetoP2.Models;

namespace ProjetoP2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiosController : ControllerBase
    {
        private readonly RoletaContextMySQL _context;

        public PremiosController(RoletaContextMySQL context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Premios>> GetPremios()
        {
                return _context.Premios.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Premios> GetPremios(int id)
        {
            var premios = _context.Premios.Find(id);

            if (premios == null)
            {
                return NotFound();
            }

            return premios;
        }

        [HttpPost]
        public ActionResult<Premios> PostPremios(Premios premios)
        {
            _context.Premios.Add(premios);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPremios), new { id = premios.Id }, premios);
        }

        [HttpPut("{id}")]
        public IActionResult PutPremios(int id, Premios premios)
        {
            if (id != premios.Id)
            {
                return BadRequest();
            }

            _context.Entry(premios).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePremios(int id)
        {
            var premios = _context.Premios.Find(id);

            if (premios == null)
            {
                return NotFound();
            }

            _context.Premios.Remove(premios);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
