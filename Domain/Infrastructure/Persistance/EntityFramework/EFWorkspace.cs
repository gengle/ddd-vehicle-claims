using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services;

namespace Domain.Infrastructure.Persistance.EntityFramework
{
    public class EFWorkspace:IWorkspace, IDisposable
    {
        private readonly EFContext _context;

        public EFWorkspace(EFContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll<T>() where T:class
        {
            return _context.Set<T>().AsQueryable();
        }

        public T GetById<T>(object id) where T:class
        {
            var obj = _context.Set<T>().Find(id);
            return obj;
        }

        public void Attach<T>(T poco) where T : class
        {
            if (_context.Entry(poco).State == EntityState.Detached)
            {
                _context.Entry(poco).State = EntityState.Added;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Commit();
        }
    }
}
