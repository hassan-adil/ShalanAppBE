using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShalanAppBE.Authentication;
using ShalanAppBE.Models;
using ShalanAppBE.Services.Interfaces;

namespace ShalanAppBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        
        [HttpGet]
        [Authorize(Roles = UserRoles.AdminUser)]
        public async Task<List<User>> GetAll()
        {
            var response = await userService.GetAll();

            return Models.User.ToModel(response);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.AdminUser)]
        public async Task<User> GetById(string id)
        {
            return (User)await userService.GetById(id);
        }

        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<User> Update(User user)
        {
            return (User)await userService.Update((Database.Entities.User)user);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<User> Delete(string id)
        {
            return (User)await userService.Delete(id);
        }
    }
}