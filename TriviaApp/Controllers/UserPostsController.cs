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
    public class UserPostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserPostsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPost>>> GetUserPost()
        {
            return await _context.UserPost.ToListAsync();
        }

        // GET: api/UserPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPost>> GetUserPost(int id)
        {
            var userPost = await _context.UserPost.FindAsync(id);

            if (userPost == null)
            {
                return NotFound();
            }

            return userPost;
        }

        [HttpGet("GetAllUserPostsByEmail/{email}")]
        public async Task<ActionResult<IEnumerable<UserPost>>> GetAllUserPostsByEmail(string email)
        {
            if (email == null)
            {
                return BadRequest();
            }

            return await _context.UserPost.Where(x => x.PostTarget == email).OrderByDescending(x => x.DatePosted).ToListAsync();
        }

        // PUT: api/UserPosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPost(int id, UserPost userPost)
        {
            if (id != userPost.UserPostId)
            {
                return BadRequest();
            }

            _context.Entry(userPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPostExists(id))
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

        // POST: api/UserPosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserPost>> PostUserPost(UserPost userPost)
        {
            _context.UserPost.Add(userPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserPost", new { id = userPost.UserPostId }, userPost);
        }

        // DELETE: api/UserPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPost(int id)
        {
            var userPost = await _context.UserPost.FindAsync(id);
            if (userPost == null)
            {
                return NotFound();
            }

            _context.UserPost.Remove(userPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserPostExists(int id)
        {
            return _context.UserPost.Any(e => e.UserPostId == id);
        }
    }
}
