using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShalanAppBE.Authentication;
using ShalanAppBE.Database.Entities;
using ShalanAppBE.Services.Interfaces;

namespace ShalanAppBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeEmploymentController : ControllerBase
    {
        private readonly IEmployeeEmploymentService employmentService;

        public EmployeeEmploymentController(IEmployeeEmploymentService employmentService)
        {
            this.employmentService = employmentService;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.AdminUser)]
        public async Task<List<EmployeeEmployment>> GetAll()
        {
            return await employmentService.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.AdminUser)]
        public async Task<EmployeeEmployment> GetById(int id)
        {
            return await employmentService.GetById(id);
        }

        [HttpGet("user/{userId}")]
        [Authorize(Roles = UserRoles.AdminUser)]
        public async Task<List<EmployeeEmployment>> GetById(string userId)
        {
            return await employmentService.GetByUserId(new Guid(userId));
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.AdminUser)]
        public async Task<EmployeeEmployment> Create(EmployeeEmployment employment)
        {
            return await employmentService.Create(employment);
        }

        [HttpPut]
        [Authorize(Roles = UserRoles.AdminUser)]
        public async Task<EmployeeEmployment> Update(EmployeeEmployment employment)
        {
            return await employmentService.Update(employment);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<EmployeeEmployment> Delete(int id)
        {
            return await employmentService.Delete(id);
        }
    }
}