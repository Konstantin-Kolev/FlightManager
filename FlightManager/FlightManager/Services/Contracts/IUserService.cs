using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;

namespace FlightManager.Services.Contracts
{
    interface IUserService
    {
        IQueryable<User> GetAllUsers();

        User GetOneUser(int id);

        void AddUser(User entity);

        void UpdateUser(User entity);

        void RemoveUser(User entity);
    }
}
