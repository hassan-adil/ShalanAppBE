using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShalanAppBE.Authentication;
using ShalanAppBE.Models;
using ShalanAppBE.Services.Interfaces;

namespace ShalanAppBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IUserService userService;

        public ReportController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("AllEmployees")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<List<User>> AllEmployeesReport()
        {
            return Models.User.ToModel(await userService.GetAll());
        }

        [HttpGet("HierarchicalEmployees")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<List<User>> HierarchicalEmployeesReport()
        {
            return Models.User.ToModel(await userService.HierarchicalReport());
        }
    }
}