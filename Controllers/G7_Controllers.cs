using EFCoreWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using static EFCoreWebApi.Models;

namespace Group7_Final_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamMemberController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TeamMemberController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TeamMember>> Get()
        {
            return Ok(_context.TeamMembers.ToList());
        }
        [HttpGet("{id}")]
        public ActionResult<TeamMember> Get(int id)
        {
            var teamMember = _context.TeamMembers.Find(id);
            if (teamMember == null)
            {
                return NotFound();
            }
            return Ok(teamMember);
        }
        [HttpPost]
        public ActionResult<TeamMember> Post([FromBody] TeamMember teamMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.TeamMembers.Add(teamMember);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = teamMember.Id }, teamMember);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TeamMember teamMember)
        {
            if (id != teamMember.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Entry(teamMember).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var teamMember = _context.TeamMembers.Find(id);
            if (teamMember == null)
            {
                return NotFound();
            }
            _context.TeamMembers.Remove(teamMember);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
