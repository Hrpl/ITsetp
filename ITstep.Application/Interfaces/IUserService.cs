using ITstep.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITstep.Application.Interfaces;

public interface IUserService
{
    public Task<User> Login(string login, string password);

    public void AddScore(int score, int id);

}
