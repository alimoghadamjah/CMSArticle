using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSArticle.Models.Context;
using CMSArticle.Models.Models;
using System.Data.Entity;

namespace CMSArticle.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        DbCMSArticleContext db;
        DbSet<T> dbSet;

        public GenericRepository(){}
        public GenericRepository(DbCMSArticleContext Context)
        {
            db = Context;
            dbSet = Context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetEntity(int id)
        {
            return dbSet.Find(id);
        }

        public bool Add(T Entity)
        {
            try
            {
               dbSet.Add(Entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(T Entity)
        {
            try
            {
                db.Entry(Entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(T Entity)
        {
            try
            {
                db.Entry(Entity).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var Entity = GetEntity(id);
                db.Entry(Entity).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
