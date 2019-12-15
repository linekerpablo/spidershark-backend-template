using System.Threading;
using System.Threading.Tasks;

namespace SpiderShark.Gateway.Data.EntityFramework.Interfaces
{
    public interface IApplicationDbContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
