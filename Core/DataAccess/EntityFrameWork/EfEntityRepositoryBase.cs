using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFrameWork
{
    public class EfEntityRepositoryBase<TEntity,TContex>:IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()
        where TContex : DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContex context = new TContex())   // IDisposable pattern implementation of c#. using ile daha performanslı. iş bitince garbage collector siler.
            {
                var addedEntity = context.Entry(entity); //referansı yakala
                addedEntity.State = EntityState.Added;   //bu aslında eklenecek bir nesne
                context.SaveChanges();                   //ve şimdi ekle
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContex context = new TContex())   // IDisposable pattern implementation of c#. using ile daha performanslı. iş bitince garbage collector siler.
            {
                var deletedEntity = context.Entry(entity); //referansı yakala
                deletedEntity.State = EntityState.Deleted; //bu aslında silinecek bir nesne
                context.SaveChanges();                     //ve şimdi sil
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            //tek data getirecek
            using (TContex context = new TContex())   // IDisposable pattern implementation of c#. using ile daha performanslı. iş bitince garbage collector siler.
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContex context = new TContex())   // IDisposable pattern implementation of c#. using ile daha performanslı. iş bitince garbage collector siler.
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContex context = new TContex())   // IDisposable pattern implementation of c#. using ile daha performanslı. iş bitince garbage collector siler.
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
