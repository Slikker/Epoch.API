using System;
using LinqToDB;
using LinqToDB.Data;

namespace API.EPOCH.BACKEND
{
    internal class DbContext : DataConnection
    {
        #region CRUD
        public ITable<T> GetList<T>() where T : BaseClass
        {
            return GetTable<T>();
        }

        public bool DataAdd<T>(T newData) where T : class
        {
            try
            {
                this.Insert(newData);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while inserting data", ex);
            }
        }

        public bool DataUpdate<T>(T newData) where T : class
        {
            try
            {
                this.Update(newData);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating data", ex);
            }
        }

        public bool DataDelete<T>(T newData) where T : class
        {
            try
            {
                this.Delete(newData);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting data.", ex);
            }
        }
        #endregion

        #region Constructor
        public DbContext(string connectionName = "Default") : base(connectionName)
        {
            LinqToDB.Common.Configuration.Linq.AllowMultipleQuery = true;
        }
        #endregion
    }
}
