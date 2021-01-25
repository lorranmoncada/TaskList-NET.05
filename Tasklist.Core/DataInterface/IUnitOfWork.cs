using System.Threading.Tasks;

namespace Tasklist.Core.DataInterface
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
