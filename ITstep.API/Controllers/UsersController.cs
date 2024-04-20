using ITstep.Domen;
using ITstep.Domen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITstep.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        protected readonly StepDbContext _db;

        public UsersController (StepDbContext db)
        {
            _db = db;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _db.Users.ToListAsync();
            if (users != null) return Ok(users);
            else return BadRequest(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser([FromRoute] int id)
        {
            var users = await _db.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (users != null) return Ok(users);
            else return BadRequest(users);
        }

        
    }
}
