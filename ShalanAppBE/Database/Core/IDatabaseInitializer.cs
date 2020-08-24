using System.Threading.Tasks;

namespace ShalanAppBE.Database.Core
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}
