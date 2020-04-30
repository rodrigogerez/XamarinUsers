using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinUsers.Model;

namespace XamarinUsers.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
    }
}
