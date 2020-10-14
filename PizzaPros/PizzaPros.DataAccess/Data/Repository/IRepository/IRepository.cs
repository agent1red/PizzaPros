using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PizzaPros.DataAccess.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // Methods usded accross all repositories: Get, GetAll, GetFirstOrDefault, Add, Remove id, Remove entity.

        T Get(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);

        //Added for removing items from cart from Summary model
        void RemoveRange(IEnumerable<T> entity);
    }
}
