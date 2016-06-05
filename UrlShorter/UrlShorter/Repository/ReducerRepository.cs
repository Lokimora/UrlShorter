using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using UrlShorter.Helpers;
using UrlShorter.Models.DB;

namespace UrlShorter.Repository
{
    public class ReducerRepository : IReducerRepository
    {

        private readonly SqlExpContext _context;

        public ReducerRepository(SqlExpContext context)
        {
            _context = context;
        }

        public Reduction Create(string originalUrl)
        {
            var existingEntry =_context.UrlReduct.FirstOrDefault<Reduction>(p => p.OriginalUrl == originalUrl);

            if (existingEntry != null)
                return existingEntry;

            var reduction = new Reduction
            {
                 OriginalUrl = originalUrl,
                 CreateDate = DateTime.Now,
                 PassageCount = 0,
                 ShortRelUrl = StringHelper.GetRandomString(10)
            };

            _context.UrlReduct.Add(reduction);
            _context.SaveChanges();

            return reduction;
        }

        public void Delete(long id)
        {
            var existingEntry = _context.UrlReduct.FirstOrDefault<Reduction>(p => p.ID == id);

            if (existingEntry != null)
            {
                _context.UrlReduct.Remove(existingEntry);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Reduction> GetAll()
        {
            return _context.UrlReduct.AsNoTracking().ToArray();
        }

        public Reduction FindFirstOrDefault(Expression<Func<Reduction, bool>> expression)
        {
            return _context.UrlReduct.FirstOrDefault(expression);
        }

        public Reduction Update(Reduction reduction)
        {
            var entry = _context.UrlReduct.FirstOrDefault(p => p.ID == reduction.ID);

            if(entry != null)
            {
                entry.PassageCount = reduction.PassageCount;
                _context.SaveChanges();

                return entry;
            }

            throw new InvalidOperationException("Запись не найдена");
        }
    }
}
