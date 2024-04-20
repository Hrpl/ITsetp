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
        // Post api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> PostUser(User user)
        {
            if (user != null)
            {
                await _db.Users.AddAsync(user);
                try
                {
                    _db.SaveChanges();
                    return BadRequest("Пользователь сохранён");
                }
                catch (Exception ex)
                {
                    return BadRequest("Ошибка сохранения пользователя");
                }
            }
            else return BadRequest("Пользователя пришёл как null");
        }
    }
}
