using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UrlShorter.Models.DB;

namespace UrlShorter.Repository
{
    public interface IReducerRepository
    {
        /// <summary>
        /// Создает запись. Если запись с таким url'ом уже существует, то просто возвращает существующую
        /// </summary>
        /// <param name="originalUrl"></param>
        /// <returns></returns>
        Reduction Create(string originalUrl);

        /// <summary>
        /// Получене всех записей (без отслеживаний (asNoTracking))
        /// </summary>
        /// <returns></returns>
        IEnumerable<Reduction> GetAll();

        /// <summary>
        /// Находит первую запись по предикату. Если ничего не найдено, то возвращает null
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Reduction FindFirstOrDefault(Expression<Func<Reduction, bool>> expression);

        void Delete(long id);

        /// <summary>
        /// Обновляет только счетчик переходов
        /// </summary>
        /// <param name="reduction"></param>
        /// <returns></returns>
        Reduction Update(Reduction reduction);
    }
}
