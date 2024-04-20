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

public class UserRepository : IUserRepository
{
    protected readonly StepDbContext _db;
    protected readonly ILogger<UserRepository> _logger;

    public UserRepository(StepDbContext db, ILogger<UserRepository> logger)
    {
        _db = db;
        _logger = logger;
    }

    /// <summary>
    /// Добавить нового пользователя
    /// </summary>
    /// <param name="user"></param>
    public void AddUserAsync(User user)
    {
        _db.Users.Add(user);
        try
        {
            _db.SaveChanges();
        }
        catch (Exception)
        {

            _logger.LogInformation("Ошибка добавления");
        }
    }

    /// <summary>
    /// Получить всех пользователей
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _db.Users.ToListAsync();
    }

    /// <summary>
    /// Получить одного пользователя
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<User> GetUserAsync(int id)
    {
        return await _db.Users.FindAsync(id);
    }
}
