using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiOnlineShop.Models;

namespace ApiOnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProductsController : ControllerBase
    {
        private readonly OnlineShopContext _context;

        public UserProductsController(OnlineShopContext context)
        {
            _context = context;
        }

        // GET: api/UserProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProduct>>> GetUserProducts()
        {
          if (_context.UserProducts == null)
          {
              return NotFound();
          }
            return await _context.UserProducts.ToListAsync();
        }

        // GET: api/UserProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserProduct>> GetUserProduct(int id)
        {
          if (_context.UserProducts == null)
          {
              return NotFound();
          }
            var userProduct = await _context.UserProducts.FindAsync(id);

            if (userProduct == null)
            {
                return NotFound();
            }

            return userProduct;
        }

        // PUT: api/UserProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserProduct(int id, UserProduct userProduct)
        {
            if (id != userProduct.UserProductId)
            {
                return BadRequest();
            }

            _context.Entry(userProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProductExists(id))
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

        // POST: api/UserProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserProduct>> PostUserProduct(UserProduct userProduct)
        {
          if (_context.UserProducts == null)
          {
              return Problem("Entity set 'OnlineShopContext.UserProducts'  is null.");
          }
            _context.UserProducts.Add(userProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserProduct", new { id = userProduct.UserProductId }, userProduct);
        }

        // DELETE: api/UserProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProduct(int id)
        {
            if (_context.UserProducts == null)
            {
                return NotFound();
            }
            var userProduct = await _context.UserProducts.FindAsync(id);
            if (userProduct == null)
            {
                return NotFound();
            }

            _context.UserProducts.Remove(userProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserProductExists(int id)
        {
            return (_context.UserProducts?.Any(e => e.UserProductId == id)).GetValueOrDefault();
        }
    }
}
