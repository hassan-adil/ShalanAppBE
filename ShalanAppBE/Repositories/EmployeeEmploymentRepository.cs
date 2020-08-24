using ShalanAppBE.Database;
using ShalanAppBE.Database.Entities;
using ShalanAppBE.Repositories.Interfaces;

namespace ShalanAppBE.Repositories
{
    public class EmployeeEmploymentRepository : RepositoryBase<EmployeeEmployment>, IEmployeeEmploymentRepository
    {
        public EmployeeEmploymentRepository(ApplicationDbContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
