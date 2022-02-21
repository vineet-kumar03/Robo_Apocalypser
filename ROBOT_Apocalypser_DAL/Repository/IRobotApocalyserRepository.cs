using System.Collections.Generic;
using System.Linq;

namespace ROBOT_Apocalypse_DAL.Repository
{

    public interface IRobotApocalyserRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void AddRange(List<T> entityList);
        void Delete(List<T> entities);
    }
}
