using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCoreAPI.Data.Abstract;

namespace TaskCoreAPI.Data.Concrete.EfCore
{
    public class EfCoreGenericRepository<TEntity, TContext> : IGenericRepository<TEntity> where TEntity : class where TContext : DbContext, new()
    {
        public void Create(TEntity entity)
        {
            using (var context=new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
           using(var context=new TContext())
            {
                var model= context.Set<TEntity>().Find(id);
                context.Set<TEntity>().Remove(model);
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
           using(var context=new TContext())
            {
               return context.Set<TEntity>().ToList();
            }
        }

        public TEntity GetById(int Id)
        {
            using(var context=new TContext())
            {
                return context.Set<TEntity>().Find(Id);
            }
        }

        public void Update(TEntity entity)
        {
            using(var context=new TContext())
            {
                context.Set<TEntity>().Update(entity);
                context.SaveChanges();
            }
        }
    }
}
