using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.DataAccessLayer.Core
{
    public class GenericDal<TC> where TC : class
    {
        private PhoneBookEntities Context;
        private IDbSet<TC> DbSet;

        public GenericDal()
        {
            Context = new PhoneBookEntities();
            DbSet = Context.Set<TC>();
        }

        public IQueryable<TC> All => Context.Set<TC>();
        public void Add(TC entity)
        {
            DbSet.Add(entity);
        }
        public IQueryable<TC> FindBy(Expression<Func<TC, bool>> predicate)
        {
            IQueryable<TC> queryable = DbSet.AsNoTracking();
            return queryable.Where(predicate);
        }
        public virtual void Update(TC entity)
        {
            DbSet.AddOrUpdate(entity);
        }
        public virtual void Remove(TC entity)
        {
            DbSet.Remove(entity);
        }
    }
}
