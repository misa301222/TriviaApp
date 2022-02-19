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
    public class RoomsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoomsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoom()
        {
            return await _context.Room.ToListAsync();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _context.Room.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        [HttpGet("GetRoomsByEmail/{email}")]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoomsByEmail(string email)
        {
            if (email == null)
            {
                return BadRequest();
            }

            return await _context.Room.Where(x => x.CreatedBy == email).ToArrayAsync();
        }

        [HttpGet("GetRoomsByEmailLike/{email}")]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoomsByEmailLike(string email)
        {
            var rooms = await _context.Room.Where(x => x.CreatedBy.Contains(email)).ToArrayAsync();

            if (rooms == null)
            {
                return null;
            }

            return rooms;
        }

        [HttpGet("GetLastFiveCreatedRooms")]
        public async Task<ActionResult<IEnumerable<Room>>> GetLastFiveCreatedRooms()
        {
            var rooms = await _context.Room.OrderByDescending(x => x.DateCreated).Take(5).ToListAsync();
            if (rooms == null)
            {
                return null;
            }

            return rooms;
        }

        [HttpGet("GetRoomsByGeneratedName/{generatedName}")]
        public async Task<ActionResult<Room>> GetRoomsByGeneratedName(string generatedName)
        {
            var room = await _context.Room.Where(x => x.GeneratedName == generatedName).FirstOrDefaultAsync();
            if(room == null)
            {
                return null;
            }
            return room;
        }

        [HttpGet("GetRoomsByGeneratedNameAndEmail/{generatedName}/{email}")]
        public async Task<ActionResult<Room>> GetRoomsByGeneratedNameAndEmail(string generatedName, string email)
        {
            if (generatedName == null)
            {
                return BadRequest();
            }

            return await _context.Room.Where(x => x.GeneratedName == generatedName && x.CreatedBy == email).FirstAsync();
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.RoomId)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.RoomId }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Room.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.RoomId == id);
        }
    }
}
