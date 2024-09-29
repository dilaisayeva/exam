using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ExamSystem.Data;
using ExamSystem.Models;

namespace ExamSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SagirdController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SagirdController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sagird
        [HttpGet]
        public IActionResult GetAllSagirdler()
        {
            var sagirdler = _context.Sagirdler.ToList();
            return Ok(sagirdler);
        }

        // GET: api/Sagird/5
        [HttpGet("{id}")]
        public IActionResult GetSagirdById(int id)
        {
            var sagird = _context.Sagirdler.FirstOrDefault(s => s.SagirdNomresi == id);
            if (sagird == null)
            {
                return NotFound();
            }
            return Ok(sagird);
        }

        // POST: api/Sagird
        [HttpPost]
        public IActionResult CreateSagird([FromBody] Sagird sagird)
        {
            if (ModelState.IsValid)
            {
                _context.Sagirdler.Add(sagird);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetSagirdById), new { id = sagird.SagirdNomresi }, sagird);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Sagird/5
        [HttpPut("{id}")]
        public IActionResult UpdateSagird(int id, [FromBody] Sagird sagird)
        {
            var existingSagird = _context.Sagirdler.FirstOrDefault(s => s.SagirdNomresi == id);
            if (existingSagird == null)
            {
                return NotFound();
            }

            existingSagird.Adi = sagird.Adi;
            existingSagird.Soyadi = sagird.Soyadi;
            existingSagird.Sinifi = sagird.Sinifi;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Sagird/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSagird(int id)
        {
            var sagird = _context.Sagirdler.FirstOrDefault(s => s.SagirdNomresi == id);
            if (sagird == null)
            {
                return NotFound();
            }

            _context.Sagirdler.Remove(sagird);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
