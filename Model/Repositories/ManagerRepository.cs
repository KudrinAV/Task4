using Model.DataModel;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public class ManagerRepository : IRepository<Manager>
    {
        private StoreAccountingContext _context;

        public ManagerRepository(StoreAccountingContext db)
        {
            _context = db;
        }

        public void Create(Manager item)
        {
            _context.Managers.Add(item);
        }

        public void Delete(int id)
        {
            Manager manager = _context.Managers.Find(id);
            if (manager != null)
                _context.Managers.Remove(manager);
        }

        public IEnumerable<Manager> Find(Func<Manager, Boolean> predicate)
        {
            return _context.Managers.Where(predicate).ToList();
        }

        public Manager Get(int id)
        {
            return _context.Managers.Find(id);
        }

        public IEnumerable<Manager> GetAll()
        {
            return _context.Managers;
        }

        public void Update(Manager item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
