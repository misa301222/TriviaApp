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
    public class UserScoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserScoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserScores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserScore>>> GetUserScore()
        {
            return await _context.UserScore.ToListAsync();
        }

        // GET: api/UserScores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserScore>> GetUserScore(int id)
        {
            var userScore = await _context.UserScore.FindAsync(id);

            if (userScore == null)
            {
                return NotFound();
            }

            return userScore;
        }

        [HttpGet("GetUserScoresByEmail/{email}")]
        public async Task<ActionResult<IEnumerable<UserScore>>> GetUserScoresByEmail(string email)
        {
            if (email == null)
            {
                return BadRequest();
            }

            return await _context.UserScore.Where(x => x.Email == email).OrderByDescending(x => x.DateSent).ToListAsync();
        }

        [HttpGet("GetTotalScoreByEmail/{email}")]
        public async Task<ActionResult<double>> GetTotalScoreByEmail(string email)
        {
            var scoreList = await _context.UserScore.Where(x => x.Email == email).ToListAsync();

            if (scoreList== null)
            {
                return NotFound();
            }
            
            var total = 0.00;
            var correct = 0.00;
            var totalScores = 0;
            foreach (var score in scoreList)
            {
                correct += score.Correct;
                totalScores += score.Correct + score.Wrong;
            }
            total = correct / totalScores;

            return total;
        }

        [HttpGet("GetTotalCorrectByEmail/{email}")]
        public async Task<ActionResult<int>> GetTotalCorrectByEmail(string email)
        {
            if (email == null)
            {
                return BadRequest();
            }
            var scoreList = await _context.UserScore.Where(x => x.Email == email).ToListAsync();
            var total = 0;
            foreach (var score in scoreList)
            {
                total += score.Correct;
            }
            return total;
        }

        [HttpGet("GetTotalWrongEmail/{email}")]
        public async Task<ActionResult<int>> GetTotalWrongByEmail(string email)
        {
            if (email == null)
            {
                return BadRequest();
            }
            var scoreList = await _context.UserScore.Where(x => x.Email == email).ToListAsync();
            var total = 0;
            foreach (var score in scoreList)
            {
                total += score.Wrong;
            }
            return total;
        }


        // PUT: api/UserScores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserScore(int id, UserScore userScore)
        {
            if (id != userScore.UserScoreId)
            {
                return BadRequest();
            }

            _context.Entry(userScore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserScoreExists(id))
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

        // POST: api/UserScores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserScore>> PostUserScore(UserScore userScore)
        {
            _context.UserScore.Add(userScore);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserScoreExists(userScore.UserScoreId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserScore", new { id = userScore.UserScoreId }, userScore);
        }

        // DELETE: api/UserScores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserScore(int id)
        {
            var userScore = await _context.UserScore.FindAsync(id);
            if (userScore == null)
            {
                return NotFound();
            }

            _context.UserScore.Remove(userScore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("DeleteAllUserScoresByEmail/{email}")]
        public async Task<IActionResult> DeleteAllUserScoresByEmail(string email)
        {
            var userScores = await _context.UserScore.Where(x => x.Email == email).ToListAsync();
            if (userScores.Count < 1)
            {
                return NotFound();
            }

            foreach(var userScore in userScores)
            {
                _context.UserScore.Remove(userScore);
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool UserScoreExists(int id)
        {
            return _context.UserScore.Any(e => e.UserScoreId == id);
        }
    }
}
