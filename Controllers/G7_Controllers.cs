using Microsoft.AspNetCore.Mvc;
using Group7_Final_Project.EFCoreWebApi.Data;
using Group7_Final_Project.EFCoreWebApi.Models;   

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
            => Ok(_context.TeamMembers.ToList());

        [HttpGet("{id}")]
        public ActionResult<TeamMember> Get(int id)
        {
            var tm = _context.TeamMembers.Find(id);
            return tm is null ? NotFound() : Ok(tm);
        }

        [HttpPost]
        public ActionResult<TeamMember> Post([FromBody] TeamMember teamMember)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.TeamMembers.Add(teamMember);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = teamMember.Id }, teamMember);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TeamMember teamMember)
        {
            if (id != teamMember.Id || !ModelState.IsValid) return BadRequest();
            _context.Entry(teamMember).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var tm = _context.TeamMembers.Find(id);
            if (tm is null) return NotFound();
            _context.TeamMembers.Remove(tm);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
