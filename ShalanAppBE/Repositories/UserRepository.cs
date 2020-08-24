using ShalanAppBE.Database;
using ShalanAppBE.Database.Entities;
using ShalanAppBE.Repositories.Interfaces;

namespace ShalanAppBE.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
