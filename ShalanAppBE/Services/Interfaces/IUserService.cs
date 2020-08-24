using ShalanAppBE.Database.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShalanAppBE.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll();

        Task<User> GetById(string id);

        Task<User> Update(User user);

        Task<User> Delete(string userId);

        Task<List<User>> HierarchicalReport();
    }
}
