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
    public class AnimalConfigsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AnimalConfigsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AnimalConfigs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalConfig>>> GetAnimalConfig()
        {
            return await _context.AnimalConfig.ToListAsync();
        }

        // GET: api/AnimalConfigs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalConfig>> GetAnimalConfig(int id)
        {
            var animalConfig = await _context.AnimalConfig.FindAsync(id);

            if (animalConfig == null)
            {
                return NotFound();
            }

            return animalConfig;
        }

        [HttpGet("GetAnimalConfigByEmail/{email}")]
        public async Task<ActionResult<AnimalConfig>> GetAnimalConfigByEmail(string email)
        {
            var animalConfig = await _context.AnimalConfig.Where(x => x.Email.Equals(email)).FirstOrDefaultAsync();

            if (animalConfig == null)
            {
                return NotFound();
            }

            return animalConfig;
        }

        // PUT: api/AnimalConfigs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalConfig(int id, AnimalConfig animalConfig)
        {
            if (id != animalConfig.AnimalConfigId)
            {
                return BadRequest();
            }

            _context.Entry(animalConfig).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalConfigExists(id))
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

        // POST: api/AnimalConfigs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimalConfig>> PostAnimalConfig(AnimalConfig animalConfig)
        {
            _context.AnimalConfig.Add(animalConfig);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimalConfig", new { id = animalConfig.AnimalConfigId }, animalConfig);
        }

        // DELETE: api/AnimalConfigs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalConfig(int id)
        {
            var animalConfig = await _context.AnimalConfig.FindAsync(id);
            if (animalConfig == null)
            {
                return NotFound();
            }

            _context.AnimalConfig.Remove(animalConfig);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("DeleteAnimalConfigByEmail/{email}")]
        public async Task<IActionResult> DeleteAnimalConfigByEmail(string email)
        {
            var animalConfig = await _context.AnimalConfig.Where(x => x.Email.Equals(email)).FirstOrDefaultAsync();

            if (animalConfig == null)
            {
                return NotFound();
            }

            _context.AnimalConfig.RemoveRange(animalConfig);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool AnimalConfigExists(int id)
        {
            return _context.AnimalConfig.Any(e => e.AnimalConfigId == id);
        }
    }
}
