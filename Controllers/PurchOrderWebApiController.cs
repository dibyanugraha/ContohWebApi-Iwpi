using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchOrderWebApi.Models;

namespace PurchOrderWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchOrderWebApiController : ControllerBase
    {
        private readonly BCPurchOrderContext _context;

        public PurchOrderWebApiController(BCPurchOrderContext context)
        {
            _context = context;
        }

        // GET: api/PurchOrderWebApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BCPurchOrder>>> GetBCPurchOrders()
        {
            return await _context.BCPurchOrder.ToListAsync();
        }

        // GET: api/PurchOrderWebApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BCPurchOrder>> GetBCPurchOrder(int id)
        {
            var bCPurchOrder = await _context.BCPurchOrder.FindAsync(id);

            if (bCPurchOrder == null)
            {
                return NotFound(); // 404
            }

            return bCPurchOrder;
        }

        // PUT: api/PurchOrderWebApi/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBCPurchOrder(int id, BCPurchOrder bCPurchOrder)
        {
            if (id != bCPurchOrder.EntryNo)
            {
                return BadRequest();
            }

            _context.Entry(bCPurchOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BCPurchOrderExists(id))
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

        // POST: api/PurchOrderWebApi
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BCPurchOrder>> PostBCPurchOrder(BCPurchOrder bCPurchOrder)
        {
            _context.BCPurchOrder.Add(bCPurchOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBCPurchOrder", new { id = bCPurchOrder.EntryNo }, bCPurchOrder);
        }

        // DELETE: api/PurchOrderWebApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BCPurchOrder>> DeleteBCPurchOrder(int id)
        {
            var bCPurchOrder = await _context.BCPurchOrder.FindAsync(id);
            if (bCPurchOrder == null)
            {
                return NotFound();
            }

            _context.BCPurchOrder.Remove(bCPurchOrder);
            await _context.SaveChangesAsync();

            return bCPurchOrder;
        }

        private bool BCPurchOrderExists(int id)
        {
            return _context.BCPurchOrder.Any(e => e.EntryNo == id);
        }
    }
}
