using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeakTaskBackend.Contexts;
using PeakTaskBackend.Models;

namespace PeakTaskBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockContext _context;

        public StockController(StockContext context)
        {
            _context = context;
        }

        // GET: api/Stock
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockItem>>> GetStocks()
        {
            return await _context.Stocks.ToListAsync();
        }

        // GET: api/Stock/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockItem>> GetStockItem(int id)
        {
            var stockItem = await _context.Stocks.FindAsync(id);

            if (stockItem == null)
            {
                return NotFound();
            }

            return stockItem;
        }

        // PUT: api/Stock/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockItem(int id, StockItem stockItem)
        {
            if (id != stockItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(stockItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockItemExists(id))
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

        // POST: api/Stock
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StockItem>> PostStockItem(StockItem stockItem)
        {
            StockItem newStock = new StockItem()
            {
                Amount = stockItem.Amount,
                Description = stockItem.Description,
                ItemNumber = stockItem.ItemNumber,
                Location = stockItem.Location,
            };
            _context.Stocks.Add(newStock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockItem", new { id = newStock.Id }, newStock);
        }

        // DELETE: api/Stock/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockItem(int id)
        {
            var stockItem = await _context.Stocks.FindAsync(id);
            if (stockItem == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stockItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockItemExists(int id)
        {
            return _context.Stocks.Any(e => e.Id == id);
        }
    }
}
