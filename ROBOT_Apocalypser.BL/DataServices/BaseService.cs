using ROBOT_Apocalypse_DAL.Models;
using ROBOT_Apocalypse_DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ROBOT_Apocalypse.BL.DataServices
{
    public class BaseService
    {
        protected Robot_ApocalypserContext rADBContext;
        private bool disposed = false;

        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        #region Consturctor
        public BaseService()
        {
            rADBContext = new Robot_ApocalypserContext();

        }

        #endregion

        #region Public Methods
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Protected Methods

        protected IRobotApocalyserRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as RobotApocalyserRepository<T>;
            }

            IRobotApocalyserRepository<T> repo = new RobotApocalyserRepository<T>(rADBContext);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        protected int SaveChanges()
        {
            return rADBContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    rADBContext.Dispose();
                }
            }
            this.disposed = true;
        }
        #endregion
    }

}
