using ITstep.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITstep.Application.Interfaces;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetAllAsync();
    public Task<User> GetUserAsync(int id);
    public void AddUserAsync(User user);

}
