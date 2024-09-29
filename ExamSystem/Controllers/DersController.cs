using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ExamSystem.Data;
using ExamSystem.Models;

namespace ExamSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Ders
        [HttpGet]
        public IActionResult GetAllDersler()
        {
            var dersler = _context.Dersler.ToList();
            return Ok(dersler);
        }

        // GET: api/Ders/5
        [HttpGet("{id}")]
        public IActionResult GetDersById(string id)
        {
            var ders = _context.Dersler.FirstOrDefault(d => d.DersKodu == id);
            if (ders == null)
            {
                return NotFound();
            }
            return Ok(ders);
        }

        // POST: api/Ders
        [HttpPost]
        public IActionResult CreateDers([FromBody] Ders ders)
        {
            if (ModelState.IsValid)
            {
                _context.Dersler.Add(ders);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetDersById), new { id = ders.DersKodu }, ders);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Ders/5
        [HttpPut("{id}")]
        public IActionResult UpdateDers(string id, [FromBody] Ders ders)
        {
            var existingDers = _context.Dersler.FirstOrDefault(d => d.DersKodu == id);
            if (existingDers == null)
            {
                return NotFound();
            }

            existingDers.DersAdi = ders.DersAdi;
            existingDers.MuellimAdi = ders.MuellimAdi;
            existingDers.MuellimSoyadi = ders.MuellimSoyadi;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Ders/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDers(string id)
        {
            var ders = _context.Dersler.FirstOrDefault(d => d.DersKodu == id);
            if (ders == null)
            {
                return NotFound();
            }

            _context.Dersler.Remove(ders);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
