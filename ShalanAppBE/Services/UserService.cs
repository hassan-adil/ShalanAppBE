using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShalanAppBE.Database.Entities;
using ShalanAppBE.Repositories.Interfaces;
using ShalanAppBE.Services.Interfaces;

namespace ShalanAppBE.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<List<User>> GetAll()
        {
            return userRepository.FindAll().ToListAsync();
        }

        public async Task<User> GetById(string id)
        {
            return await userRepository.FindAsync(id);
        }

        public async Task<User> Update(User user)
        {
            await userRepository.UpdateAsync(user);

            return await userRepository.FindAsync(user.Id);
        }

        public async Task<User> Delete(string userId)
        {
            var user = await userRepository.FindAsync(userId);

            await userRepository.DeleteAsync(user);

            return user;
        }

        public async Task<List<User>> HierarchicalReport()
        {
            return await userRepository.FindAll().OrderByDescending(x => x.Position).ToListAsync();
        }
    }
}
