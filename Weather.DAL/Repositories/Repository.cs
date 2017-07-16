using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.DAL.Infrastructure;
using Weather.DAL.Interfaces;

namespace Weather.DAL.Repositories
{
    public class Repository<T>:IRepository<T> where T : class
    {
        private WeatherDb _db;
        private DbSet<T> _set;

        public Repository(WeatherDb db)
        {
            _db = db;
            _set = _db.Set<T>();
        }

        public void Create(T item)
        {
            _set.Add(item);
        }

        public void Delete(T item)
        {
            _set.Remove(item);
        }

        public T Get(int id)
        {
            return _set.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _set.ToList();
        }

        public void Update(T item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }

}
