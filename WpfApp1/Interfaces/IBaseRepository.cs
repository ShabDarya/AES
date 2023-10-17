using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Interfaces
{
    public interface IBaseRepository<T>
        where T : class
    {
        Task AddAsync(T item); // добавление объекта
        Task AddRangeAsync(ICollection<T> item); // добавление объекта
        Task UpdateAsync(T item); // обновление объекта
        Task SaveAsync();  // сохранение изменений
        Task<IEnumerable<T>> RemoveRangeAsync(Func<T, bool> predicate); // удаление объекта по id
        IQueryable<T> GetEntityQuery();
    }
}
