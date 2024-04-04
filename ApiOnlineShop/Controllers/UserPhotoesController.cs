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
    public class UserPhotoesController : ControllerBase
    {
        private readonly OnlineShopContext _context;

        public UserPhotoesController(OnlineShopContext context)
        {
            _context = context;
        }

        // GET: api/UserPhotoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPhoto>>> GetUserPhotos()
        {
          if (_context.UserPhotos == null)
          {
              return NotFound();
          }
            return await _context.UserPhotos.ToListAsync();
        }

        // GET: api/UserPhotoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPhoto>> GetUserPhoto(int id)
        {
          if (_context.UserPhotos == null)
          {
              return NotFound();
          }
            var userPhoto = await _context.UserPhotos.FindAsync(id);

            if (userPhoto == null)
            {
                return NotFound();
            }

            return userPhoto;
        }

        // PUT: api/UserPhotoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPhoto(int id, UserPhoto userPhoto)
        {
            if (id != userPhoto.IdPhoto)
            {
                return BadRequest();
            }

            _context.Entry(userPhoto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPhotoExists(id))
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

        // POST: api/UserPhotoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserPhoto>> PostUserPhoto(UserPhoto userPhoto)
        {
          if (_context.UserPhotos == null)
          {
              return Problem("Entity set 'OnlineShopContext.UserPhotos'  is null.");
          }
            _context.UserPhotos.Add(userPhoto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserPhoto", new { id = userPhoto.IdPhoto }, userPhoto);
        }

        // DELETE: api/UserPhotoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPhoto(int id)
        {
            if (_context.UserPhotos == null)
            {
                return NotFound();
            }
            var userPhoto = await _context.UserPhotos.FindAsync(id);
            if (userPhoto == null)
            {
                return NotFound();
            }

            _context.UserPhotos.Remove(userPhoto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserPhotoExists(int id)
        {
            return (_context.UserPhotos?.Any(e => e.IdPhoto == id)).GetValueOrDefault();
        }
    }
}
