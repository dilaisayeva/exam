using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ExamSystem.Data;
using ExamSystem.Models;

namespace ExamSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImtahanController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ImtahanController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Imtahan
        [HttpGet]
        public IActionResult GetAllImtahanlar()
        {
            var imtahanlar = _context.Imtahanlar.ToList();
            return Ok(imtahanlar);
        }

        // GET: api/Imtahan/5
        [HttpGet("{id}")]
        public IActionResult GetImtahanById(int id)
        {
            var imtahan = _context.Imtahanlar.FirstOrDefault(i => i.ImtahanID == id);
            if (imtahan == null)
            {
                return NotFound();
            }
            return Ok(imtahan);
        }

        // POST: api/Imtahan
        [HttpPost]
        public IActionResult CreateImtahan([FromBody] Imtahan imtahan)
        {
            if (ModelState.IsValid)
            {
                _context.Imtahanlar.Add(imtahan);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetImtahanById), new { id = imtahan.ImtahanID }, imtahan);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Imtahan/5
        [HttpPut("{id}")]
        public IActionResult UpdateImtahan(int id, [FromBody] Imtahan imtahan)
        {
            var existingImtahan = _context.Imtahanlar.FirstOrDefault(i => i.ImtahanID == id);
            if (existingImtahan == null)
            {
                return NotFound();
            }

            existingImtahan.DersKodu = imtahan.DersKodu;
            existingImtahan.SagirdNomresi = imtahan.SagirdNomresi;
            existingImtahan.ImtahanTarixi = imtahan.ImtahanTarixi;
            existingImtahan.Qiymeti = imtahan.Qiymeti;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Imtahan/5
        [HttpDelete("{id}")]
        public IActionResult DeleteImtahan(int id)
        {
            var imtahan = _context.Imtahanlar.FirstOrDefault(i => i.ImtahanID == id);
            if (imtahan == null)
            {
                return NotFound();
            }

            _context.Imtahanlar.Remove(imtahan);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
