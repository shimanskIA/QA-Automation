using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Interfaces
{
    interface IRepository
    {
        public interface IRepository<T> where T : class
        {
            int Add(T obj);
            void Update(T obj);
            void Remove(int id);
            void Save();
            T Find(int id);
            IEnumerable<T> GetAll();
        }
    }
}
