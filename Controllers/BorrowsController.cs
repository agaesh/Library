using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;

namespace Library.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BorrowsController  : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public BorrowsController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: borrows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Borrows>>> GetBorrows(
            [FromQuery] string? status,
            [FromQuery] int? userId)
        {
            var query = _context.Borrows.AsQueryable();

            if (status == "active")
                query = query.Where(b => b.ReturnDate == null);

            if (status == "return")
                query = query.Where(b => b.ReturnDate != null);

            if (status == "overdue")
                query = query.Where(b => b.DueDate < DateTime.Now && b.ReturnDate == null);

            if (userId != null)
                query = query.Where(b => b.MemberId == userId);

            return Ok(await query.Take(100).ToListAsync());
        }

        // GET: api/borrows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Borrows>> GetBorrow(int id)
        {
            var borrow = await _context.Borrows.FindAsync(id);
            if (borrow == null) return NotFound();
            return Ok(borrow);
        }

        // POST: api/borrows
        [HttpPost]
        public async Task<ActionResult<Borrows>> CreateBorrow(Borrows borrow)
        {
            borrow.CreateDate = DateTime.UtcNow;
            borrow.BorrowDate = DateTime.UtcNow;
            borrow.IsReturned = false;
            borrow.FineAmount = 0;

            _context.Borrows.Add(borrow);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBorrow), new { id = borrow.Id }, borrow);
        }

        // PUT: borrows/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBorrow(int id, Borrows borrow)
        {
            if (id != borrow.Id) return BadRequest();

            borrow.UpdateDate = DateTime.UtcNow;
            _context.Entry(borrow).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // PATCH: borrows/5/return
        [HttpPatch("{id}/return")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var borrow = await _context.Borrows.FindAsync(id);
            if (borrow == null) return NotFound();

            borrow.IsReturned = true;
            borrow.ReturnDate = DateTime.UtcNow;
            borrow.UpdateDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return Ok(borrow);
        }

        // DELETE: borrows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrow(int id)
        {
            var borrow = await _context.Borrows.FindAsync(id);
            if (borrow == null) return NotFound();

            _context.Borrows.Remove(borrow);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
