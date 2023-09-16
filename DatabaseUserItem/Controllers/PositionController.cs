using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseUserItem.Database;
using DatabaseUserItem.Models;
using DatabaseUserItem.Models.Dtos;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;

namespace DatabaseUserItem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly CompanyContext _context;

        public PositionController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/<UserController>
        [HttpGet("{id}/GetUserItems")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserItems(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Positions
                .Include(x => x.Users)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.Users);
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> Get()
        {
            return await _context.Positions
                .Include(x => x.Users)
               .ToListAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PositionDTO>> Get(int id)
        {
            if (_context.Positions == null)
            {
                return NotFound();
            }

            var user = await _context.Positions.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return PositionToDTO(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PositionDTO position)
        {
            if (_context.Positions == null)
            {
                return Problem("Entity set 'TodoContext.TodoItems'  is null.");
            }

            var localPosition = new Position
            {
                 Position_name = position.Position_name,
                  CompanyId = position.CompanyId,
            };

            _context.Positions.Add(localPosition);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private static PositionDTO PositionToDTO(Position position) =>
             new()
             {
                 Id = position.Id,
                 Position_name = position.Position_name,
                 CompanyId = position.CompanyId,
                
             };
    }
}
