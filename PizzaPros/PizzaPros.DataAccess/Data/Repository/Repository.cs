using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PizzaPros.DataAccess.Data.Repository
{
    public class Repository<T> where T : class
    {
        //Access the database 
        protected readonly DbContext Context;
        internal DbSet<T> dbSet;

        //Initialize using dependency injection in the constructor
        public Repository(DbContext context)
        {
            Context = context; // Set Context
            this.dbSet = context.Set<T>(); // Set dbSet Object to use to add or remove anything
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            // Check for filter, then includeProperties, then orderBy clause.
            //if filter != null then append querry 
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //Include properties will be comma seperated
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            // Check for filter, then includeProperties, then orderBy clause.
            //if filter != null then append querry 
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //Include properties will be comma seperated
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            T entityToRemove = dbSet.Find(id);
            Remove(entityToRemove);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        // Added to remove items from cart from Summary Model 
        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
