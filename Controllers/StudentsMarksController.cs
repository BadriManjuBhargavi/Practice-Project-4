using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PProject4.Models;

namespace PProject4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsMarksController : ControllerBase
    {
        private readonly RainSchoolDbContext _context;

        public StudentsMarksController(RainSchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentsMarks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsMark>>> GetStudentsMarks()
        {
          if (_context.StudentsMarks == null)
          {
              return NotFound();
          }
            return await _context.StudentsMarks.ToListAsync();
        }

        // GET: api/StudentsMarks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentsMark>> GetStudentsMark(int id)
        {
          if (_context.StudentsMarks == null)
          {
              return NotFound();
          }
            var studentsMark = await _context.StudentsMarks.FindAsync(id);

            if (studentsMark == null)
            {
                return NotFound();
            }

            return studentsMark;
        }

        // PUT: api/StudentsMarks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentsMark(int id, StudentsMark studentsMark)
        {
            if (id != studentsMark.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentsMark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsMarkExists(id))
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

        // POST: api/StudentsMarks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentsMark>> PostStudentsMark(StudentsMark studentsMark)
        {
          if (_context.StudentsMarks == null)
          {
              return Problem("Entity set 'RainSchoolDbContext.StudentsMarks'  is null.");
          }
            _context.StudentsMarks.Add(studentsMark);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentsMarkExists(studentsMark.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentsMark", new { id = studentsMark.Id }, studentsMark);
        }

        // DELETE: api/StudentsMarks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentsMark(int id)
        {
            if (_context.StudentsMarks == null)
            {
                return NotFound();
            }
            var studentsMark = await _context.StudentsMarks.FindAsync(id);
            if (studentsMark == null)
            {
                return NotFound();
            }

            _context.StudentsMarks.Remove(studentsMark);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentsMarkExists(int id)
        {
            return (_context.StudentsMarks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
