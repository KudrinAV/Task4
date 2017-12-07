using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T get(int id);
        IEnumerable<T> Find();
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
