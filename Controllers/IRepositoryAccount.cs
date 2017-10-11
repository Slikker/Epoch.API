using System.Threading.Tasks;

namespace API.EPOCH.BACKEND
{
    public interface IRepositoryAccount<T> : IRepository<T> where T : IAccount
    {

    }
}
