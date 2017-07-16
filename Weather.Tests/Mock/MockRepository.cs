using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.DAL.Interfaces;

namespace Weather.Tests.Mock
{
    public class MockRepository<T>:IRepository<T> where T:class
    {
        private readonly List<T> _list;
        public MockRepository()
        {
            _list=new List<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _list;
        }

        public T Get(int id)
        {
            
            return _list.FirstOrDefault(i => Convert.ToInt32(i.GetType().GetProperty("Id").GetValue(i,null))==id);
          
        }

        public void Create(T item)
        {
            _list.Add(item);
        }

        public void Update(T item)
        {
            if (!_list.Contains(item))
            {
                _list.Add(item);
            }
        }

        public void Delete(T item)
        {
            _list.Remove(item);
        }
    }
}
