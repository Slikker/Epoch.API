using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace API.EPOCH.BACKEND
{
    public class RepositoryAccount<T> : Repository<T>, IRepositoryAccount<T> where T : Account
    {
		public RepositoryAccount(ILogger<RepositoryAccount<Account>> logger)
			:base(logger)
		{

		}
    }
}