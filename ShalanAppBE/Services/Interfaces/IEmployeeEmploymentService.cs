using ShalanAppBE.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShalanAppBE.Services.Interfaces
{
    public interface IEmployeeEmploymentService
    {
        Task<List<EmployeeEmployment>> GetAll();

        Task<List<EmployeeEmployment>> GetByUserId(Guid userId);

        Task<EmployeeEmployment> GetById(int id);

        Task<EmployeeEmployment> Create(EmployeeEmployment employeeEmployment);

        Task<EmployeeEmployment> Update(EmployeeEmployment employeeEmployment);

        Task<EmployeeEmployment> Delete(int employeeEmploymentId);
    }
}
