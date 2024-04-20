using ITstep.Application.Interfaces;
using ITstep.Application.Services;
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
        protected readonly IUserRepository _repo;
        protected readonly IUserService _service;
        public UsersController (StepDbContext db, IUserRepository repo, IUserService service)
        {
            _db = db;
            _repo = repo;
            _service = service;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _repo.GetAllAsync();
            if (users != null) return Ok(users);
            else return BadRequest(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser([FromRoute] int id)
        {
            var users = await _repo.GetUserAsync(id);
            if (users != null) return Ok(users);
            else return BadRequest(users);
        }

        // Post api/<UsersController>
        [HttpPost ]
        public async Task<ActionResult> PostUser(User user)
        {
            if (user != null)
            {
                _repo.AddUserAsync(user);
                return Ok("Пользователь добавлен");
            }
            else return BadRequest("Пользователя пришёл как null");
        }


        [HttpGet("Auth")]
        public async Task<ActionResult<User>> Login(string login, string password)
        {
            var user  = await _service.Login(login, password);
            if (user != null) return Ok(user);
            else return BadRequest(user);
        }
    }
}
