using System.Threading.Tasks;

namespace TestTemplate3.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
    }
}