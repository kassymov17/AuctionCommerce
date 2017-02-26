using System.Linq;

namespace AC.Data.Abstract
{
    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> GetAll();
        T GetOne(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
