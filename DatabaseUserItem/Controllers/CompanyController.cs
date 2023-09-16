using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseUserItem.Database;
using DatabaseUserItem.Models;
using DatabaseUserItem.Models.Dtos;
using Azure.Identity;

namespace DatabaseUserItem.Controllers
{
 
        [Route("api/[controller]")]
        [ApiController]
        public class CompanyController : ControllerBase
        {
            private readonly CompanyContext _context;

            public CompanyController(CompanyContext context)
            {
                _context = context;
            }

            // GET: api/<UserController>
            [HttpGet("{id}/GetUserItems")]
            public async Task<ActionResult<IEnumerable<Position>>> GetTeamItems(int id)
            {
                if (_context.Users == null)
                {
                    return NotFound();
                }

                var team = await _context.Teams
                    .Include(x => x.Positions).ThenInclude(x => x.Users)
                    .SingleOrDefaultAsync(x => x.Id == id);

                if (team == null)
                {
                    return NotFound();
                }

                return Ok(team.Positions);
            }

            // GET: api/<UserController>
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Company>>> Get()
            {
                return await _context.Teams
                    .Include(x => x.Positions).ThenInclude(x => x.Users)
                   .ToListAsync();
            }
       
        // GET api/<UserController>/5
            [HttpGet("Company-name/{name}")]
            public async Task<ActionResult<CompanyDTO>> Get(string name)
            {
            var result = await _context.Teams
            .Where(x => x.Name.Contains(name))
            .Include(x => x.Positions).ThenInclude(x => x.Users)
            .ToListAsync();

            return Ok(result);
            
            }
            [HttpGet("by-position/{position_name}")]
            public async Task<ActionResult<IEnumerable<Position>>> GetTeamsByPosition(string position_name)
            {
            var teamsWithPosition = await _context.Teams
                .Where(team => team.Positions.Any(position => position.Position_name == position_name))
                .Include(x => x.Positions).ThenInclude(x=>x.Users)
                .ToListAsync();
             
           

            return Ok(teamsWithPosition);
            }


        // POST api/<UserController>
        [HttpPost]
            public async Task<ActionResult> Post([FromBody] CompanyDTO team)
            {
                if (_context.Teams == null)
                {
                    return Problem("Entity set 'TodoContext.TodoItems'  is null.");
                }

                var localTeam = new Company
                {
                    Name = team.Name,
                    Manager = team.Manager,
                    Description = team.Description,
                    
                };

                _context.Teams.Add(localTeam);
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

            private static CompanyDTO TeamToDTO(Company team) =>
             new()
             {
                 Id = team.Id,
                 Name = team.Name,
                 Manager = team.Manager,
                 Description = team.Description,
             };
        
    }
}
