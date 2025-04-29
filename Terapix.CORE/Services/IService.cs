using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Terapix.CORE.Services
{
    public interface IService<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAssync(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        int Count();
        void update(T entity);
        void ChangeStatus(T entity);
        Task<T> AddyAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }
}
