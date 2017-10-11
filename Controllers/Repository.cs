using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace API.EPOCH.BACKEND
{
    public class Repository<T> : IRepository<T> where T : BaseClass
    {
        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression)
        {
            await Log(100, "Get Task", "Getting list");
			return await Task.Run(() =>
            {
				using (var dtx = new DbContext())
                {
					return dtx.GetList<T>().Where(expression).ToList();
                }
            });
        }

		public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
		{
			await Log(101, "Get", "Getting");
            return await Task.Run(() =>
			{
				using (var dtx = new DbContext())
				{
					return dtx.GetList<T>().Where(expression).FirstOrDefault();
				}
			});
		}

		public async Task<bool> DataAddAsync(T newData)
        {
			await Log(102, "ADD", "Adding");
            return await Task.Run(() =>
            {
                using (var dtx = new DbContext())
                {
                    return dtx.DataAdd(newData);
                }
            });
        }

        public async Task<bool> DataUpdateAsync(T newData)
        {
			await Log(103, "Update", "Updating");
            return await Task.Run(() =>
            {
                using (var dtx = new DbContext())
                {
                    return dtx.DataAdd(newData);
                }
            });
        }

        public async Task<bool> DataDeleteAsync(T newData)
        {
			await Log(104, "Delete", "Deleting");
            return await Task.Run(() =>
            {
                using (var dtx = new DbContext())
                {
                    return dtx.DataDelete(newData);
                }
            });
        }

		private async Task Log(int eventId, string eventName, string message)
		{
			await Task.Run(() => {
				if (logger != null)
				{
					Type type = typeof(T);
					logger.LogDebug(new EventId(eventId, eventName), $"{message} - {type.Name}", null);
				}
			});
		}

		public Repository(ILogger logger)
		{
			this.logger = logger;
		}

		protected readonly ILogger logger;
    }
}
