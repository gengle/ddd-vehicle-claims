using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IWorkspace
    {
        IQueryable<T> GetAll<T>() where T : class;
        T GetById<T>(object id) where T : class;
        void Attach<T>(T poco) where T : class;
        void Commit();
    }
}
