using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project3.Models;

namespace Project3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QexamsController : ControllerBase
    {
        private readonly Projectky3Context _context;

        public QexamsController(Projectky3Context context)
        {
            _context = context;
        }

        // GET: api/Qexams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Qexam>>> GetQexams()
        {
            return await _context.Qexams.ToListAsync();
        }

        // GET: api/Qexams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Qexam>> GetQexam(int id)
        {
            var qexam = await _context.Qexams.FindAsync(id);

            if (qexam == null)
            {
                return NotFound();
            }

            return qexam;
        }

        // PUT: api/Qexams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQexam(int id, Qexam qexam)
        {
            if (id != qexam.Id)
            {
                return BadRequest();
            }

            _context.Entry(qexam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QexamExists(id))
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

        // POST: api/Qexams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Qexam>> PostQexam(Qexam qexam)
        {
            _context.Qexams.Add(qexam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQexam", new { id = qexam.Id }, qexam);
        }

        // DELETE: api/Qexams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQexam(int id)
        {
            var qexam = await _context.Qexams.FindAsync(id);
            if (qexam == null)
            {
                return NotFound();
            }

            _context.Qexams.Remove(qexam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QexamExists(int id)
        {
            return _context.Qexams.Any(e => e.Id == id);
        }
    }
}
