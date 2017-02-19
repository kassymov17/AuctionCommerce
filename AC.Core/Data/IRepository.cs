using System.Collections.Generic;
using System.Linq;

namespace AC.Core.Data
{
    public partial interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Получить сущность по ид
        /// </summary>
        /// <param name="id">ИД</param>
        /// <returns>Сущность</returns> 
        T GetById(object id);

        /// <summary>
        /// Вставить сущность
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Insert(T entity);

        /// <summary>
        /// Добавить коллекцию сущностей
        /// </summary>
        /// <param name="entities">Коллекция сущностей</param>
        void Insert(IEnumerable<T> entities);

        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Update(T entity);

        /// <summary>
        /// Обновить сущности
        /// </summary>
        /// <param name="entities">Сущности</param>
        void Update(IEnumerable<T> entities);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Delete(T entity);

        /// <summary>
        /// Удаляет коллекцию сущностей
        /// </summary>
        /// <param name="entities">Сущности</param>
        void Delete(IEnumerable<T> entities);
        
        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<T> Table { get; }
        
        IQueryable<T> TableNoTracking { get; }

    }
}
