using Microsoft.EntityFrameworkCore;
using ShalanAppBE.Database.Entities;
using ShalanAppBE.Repositories.Interfaces;
using ShalanAppBE.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShalanAppBE.Services
{
    public class EmployeeEmploymentService : IEmployeeEmploymentService
    {
        private readonly IEmployeeEmploymentRepository employmentRepository;

        public EmployeeEmploymentService(IEmployeeEmploymentRepository employmentRepository)
        {
            this.employmentRepository = employmentRepository;
        }

        public Task<List<EmployeeEmployment>> GetAll()
        {
            return employmentRepository.FindAll().ToListAsync();
        }

        public async Task<EmployeeEmployment> GetById(int id)
        {
            return await employmentRepository.FindAsync(id);
        }

        public async Task<List<EmployeeEmployment>> GetByUserId(Guid userId)
        {
            return await employmentRepository.FindByCondition(x => x.EmployeeId == userId.ToString()).ToListAsync();
        }

        public async Task<EmployeeEmployment> Create(EmployeeEmployment employeeEmployment)
        {
            await employmentRepository.CreateAsync(employeeEmployment);

            return await employmentRepository.FindAsync(employeeEmployment.Id);
        }

        public async Task<EmployeeEmployment> Update(EmployeeEmployment employeeEmployment)
        {
            await employmentRepository.UpdateAsync(employeeEmployment);

            return await employmentRepository.FindAsync(employeeEmployment.Id);
        }

        public async Task<EmployeeEmployment> Delete(int employeeEmploymentId)
        {
            var employment = await employmentRepository.FindAsync(employeeEmploymentId);

            await employmentRepository.DeleteAsync(employment);

            return employment;
        }
    }
}
