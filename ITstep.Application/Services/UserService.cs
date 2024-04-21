using ITstep.Application.Interfaces;
using ITstep.Domen;
using ITstep.Domen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITstep.Application.Services;

public class UserService : IUserService
{
    protected readonly StepDbContext _db;
    protected readonly ILogger<UserService> _logger;

    public UserService(StepDbContext db, ILogger<UserService> logger)
    {
        _db = db;
        _logger = logger;
    }

    public void AddScore(int score, int id)
    {
        var user = _db.Users.Find(id);
        user.Score += score;

        _db.Users.Update(user);

        try
        {
            _db.SaveChanges();
            _logger.LogInformation("Очки добавлены");
        }
        catch (Exception)
        {

            _logger.LogError("Очки не добавлены");
        }
    }

    public async Task<User> Login(string login, string password)
    {
        var user = await _db.Users.Where(p => p.Login == login && p.Password == password).FirstOrDefaultAsync();
        return user;
    }
}
