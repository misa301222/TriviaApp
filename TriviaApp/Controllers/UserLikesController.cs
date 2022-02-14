#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TriviaApp.Data;
using TriviaApp.Data.Entities;

namespace TriviaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLikesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserLikesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserLikes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLike>>> GetUserLike()
        {
            return await _context.UserLike.ToListAsync();
        }

        // GET: api/UserLikes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserLike>> GetUserLike(string id)
        {
            var userLike = await _context.UserLike.FindAsync(id);

            if (userLike == null)
            {
                return NotFound();
            }

            return userLike;
        }

        [HttpGet("GetAllUserLikesByUserPostId/{userPostId}")]
        public async Task<ActionResult<IEnumerable<UserLike>>> GetAllUserLikesByUserPostId(int userPostId)
        {
            var userLike = await _context.UserLike.Where(x => x.UserPostId == userPostId).ToListAsync();

            if (userLike == null)
            {
                return null;
            }

            return userLike;
        }

        [HttpGet("GetLikeByEmailAndUserPostId/{email}/{userPostId}")]
        public async Task<ActionResult<UserLike>> GetLikeByEmailAndUserPostId(string email, int userPostId)
        {
            var userLike = await _context.UserLike.Where(x => x.Email == email && x.UserPostId == userPostId).FirstOrDefaultAsync();

            if (userLike == null)
            {
                return null;
            }

            return userLike;
        }

        // PUT: api/UserLikes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLike(string id, UserLike userLike)
        {
            if (id != userLike.Email)
            {
                return BadRequest();
            }

            _context.Entry(userLike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLikeExists(id))
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

        // POST: api/UserLikes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserLike>> PostUserLike(UserLike userLike)
        {
            _context.UserLike.Add(userLike);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserLikeExists(userLike.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserLike", new { id = userLike.Email }, userLike);
        }

        // DELETE: api/UserLikes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserLike(string id)
        {
            var userLike = await _context.UserLike.FindAsync(id);
            if (userLike == null)
            {
                return NotFound();
            }

            _context.UserLike.Remove(userLike);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("DeleteLikesByUserPostId/{userPostId}")]
        public async Task<IActionResult> DeleteLikesByUserPostId(int userPostId)
        {
            var userLike = await _context.UserLike.Where(x => x.UserPostId == userPostId).ToListAsync();
            _context.UserLike.RemoveRange(userLike);
            await _context.SaveChangesAsync();

            return Ok(userLike);
        }

        [HttpDelete("DeleteUserLikeByEmailAndUserPostId/{email}/{userPostId}")]
        public async Task<IActionResult> DeleteUserLikeByEmailAndUserPostId(string email, int userPostId)
        {
            var userLike = await _context.UserLike.Where(x => x.Email == email && x.UserPostId == userPostId).FirstOrDefaultAsync();

            _context.UserLike.Remove(userLike);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool UserLikeExists(string id)
        {
            return _context.UserLike.Any(e => e.Email == id);
        }
    }
}
